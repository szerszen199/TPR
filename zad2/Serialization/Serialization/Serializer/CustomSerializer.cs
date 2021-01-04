using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;


namespace Serialization.Serializer
{
    public class CustomSerializer : Formatter
    {
        private string output;
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public CustomSerializer()
        {
            Binder = new Binder();
            Context = new StreamingContext();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable Object = (ISerializable)graph;
            SerializationInfo serializationInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
            Object.GetObjectData(serializationInfo, Context);
            Binder.BindToName(serializationInfo.ObjectType, out string assemblyName, out string typeName);
            output += '#' + assemblyName + ";" + typeName + "\n{\n";
            long id = m_idGenerator.GetId(graph, out _);
            output += id.GetType() + ";#id;" + id + '\n';
            foreach (SerializationEntry property in serializationInfo)
            {
                WriteMember(property.Name, property.Value);
                output += '\n';
            }
            output += "}\n";            

            while (m_objectQueue.Count != 0)
            {
                Serialize(null, m_objectQueue.Dequeue());
            }
            if (serializationStream != null)
            {
                using StreamWriter streamWriter = new StreamWriter(serializationStream);
                streamWriter.Write(output);
            }
        }

        public override object Deserialize(Stream serializationStream)
        {
            object Object = null;
            Type objectType = null;
            string streamContent;
            Dictionary<long, object> DeserializedObjects = new Dictionary<long, object>();
            long tempID = 0;
            long rootID = -1;
            streamContent = new StreamReader(serializationStream).ReadToEnd();            
            string[] lines = streamContent.Split('\n');
            foreach (string line in lines)
            {
                if (line.Length == 0)
                    break;
                if (line[0] == '#')
                {
                    string[] parted = line[1..].Split(';');
                    objectType = Binder.BindToType(parted[0], parted[1]);
                    Object = Activator.CreateInstance(objectType);                  
                }
                else if (line.Equals("}"))
                    DeserializedObjects.Add(tempID, Object);
                else if (line.Contains(";"))
                {
                    string[] TypeKeyValue = line.Split(';');
                    if (TypeKeyValue[1].Equals("#id"))
                    {
                        Type idType = Type.GetType(TypeKeyValue[0]);
                        tempID = (long)Convert.ChangeType(TypeKeyValue[2], idType, CultureInfo.InvariantCulture);
                        if (rootID < 0)
                            rootID = tempID;
                    }
                    else if (TypeKeyValue[2].Contains("$")){}
                    else
                    {
                        Type propertyType = Type.GetType(TypeKeyValue[0]);
                        PropertyInfo propertyInfo = objectType.GetProperty(TypeKeyValue[1]);
                        propertyInfo.SetValue(Object, Convert.ChangeType(TypeKeyValue[2], propertyType, CultureInfo.InvariantCulture));
                    }
                }
            }
            Reference(DeserializedObjects, lines);

            return DeserializedObjects[rootID];
        }



        public void Reference(Dictionary<long, object> objects, string[] lines)
        {
            object operationObject = null;
            Type objectType = null;
            Type idType = null;
            foreach (string line in lines)
            {
                if (line.Length == 0)
                    break;
                if (line[0] == '#')
                {
                    string[] split = line[1..].Split(';');
                    objectType = Binder.BindToType(split[0], split[1]);
                }
                if (line.Contains("#id"))
                {
                    string[] TypeKeyValue = line.Split(';');
                    if (idType == null)
                        idType = Type.GetType(TypeKeyValue[0]);
                    operationObject = objects[(long)Convert.ChangeType(TypeKeyValue[2], idType, CultureInfo.InvariantCulture)];
                }
                if (line.Contains(";$("))
                {
                    string[] TypeKeyValue = line.Split(';');
                    string pureIdStr = TypeKeyValue[2].Trim(new Char[] { '$','(', ')' });
                    PropertyInfo propertyInfo = objectType.GetProperty(TypeKeyValue[1]);
                    propertyInfo.SetValue(operationObject, objects[(long)Convert.ChangeType(pureIdStr, idType, CultureInfo.InvariantCulture)]);
                }
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            val = val.ToUniversalTime();
            output += val.GetType() + ";" + name + ";" + val.ToString("u", CultureInfo.InvariantCulture);
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            output += val.GetType() + ";" + name + ";" + val.ToString(CultureInfo.InvariantCulture);
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            output += val.GetType() + ";" + name + ";" + val.ToString(CultureInfo.InvariantCulture);
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            {
                if (memberType.Equals(typeof(string)))
                {
                    output += memberType + ";" + name + ";" + obj.ToString();
                }
                else
                {
                    output += memberType + ";" + name + ";$(" + m_idGenerator.GetId(obj, out bool first).ToString() + ')';
                    if (first)
                    {
                        m_objectQueue.Enqueue(obj);
                    }
                }
            }
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}

