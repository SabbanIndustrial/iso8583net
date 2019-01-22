﻿using ISO8583Net.Packager;
using Microsoft.Extensions.Logging;
using System;

namespace ISO8583Net.Field
{
    public class ISOField : ISOComponent
    {
        private ISOPackager m_packager;

        public ISOField(ILogger logger, ISOPackager packager, int number, String value) : base(logger, number, value)
        {          
            m_packager = packager;
        }

        public ISOField(ILogger logger, ISOPackager packager, int number) : base(logger, number)
        {
            m_packager = packager;
        }

        public override void SetValue(string value)
        {
            m_value = value;
        }

        public override void SetFieldValue(int fieldNumber, string fieldValue)
        {
            throw new NotImplementedException();
        }

        public override void SetFieldValue(int fieldNumber, String tag, String tagValue)
        {
            throw new NotImplementedException();
        }   

        public override String GetValue()
        {
            return m_value;
        }

        public override String GetFieldValue(int fieldNumber)
        {
            throw new NotImplementedException();
        }

        public override String GetFieldValue(int fieldNumber, int subField)
        {
            throw new NotImplementedException();
        }

        public override String GetFieldValue(int fieldNumber, string tag, string tagValue)
        {
            throw new NotImplementedException();
        }

        public override void Trace()
        {
            Logger.LogInformation("Field [" + m_number.ToString().PadLeft(3, '0') + "]".PadRight(5, ' ') + "[" + m_value + "]");
        }

        public override String ToString()
        {
            //return (String.Format("Field [{0}]{1}[{2}]\n", m_number.ToString().PadLeft(3, '0'), " ".PadLeft(4, ' '), m_value));

            return (String.Format("Field [{0}]{1}[{2}]\n{3}", m_number.ToString().PadLeft(3, '0')," ".PadRight(4, ' '), m_value, m_packager.InterpretField(m_value)));
        }
    }
}