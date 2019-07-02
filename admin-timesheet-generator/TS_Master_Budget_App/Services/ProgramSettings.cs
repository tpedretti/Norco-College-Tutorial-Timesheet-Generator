using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TS_Master_Budget_App.Services
{
    public class ProgramSettings
    {
        internal string _mainBud;
        public string mainBud
        {
            get { return _mainBud; }
            set { _mainBud = value; }
        }

        internal string _warningThresholds;
        public string warningThresholds
        {
            get { return _warningThresholds; }
            set { _warningThresholds = value; }
        }

        internal string _stopThreshold;
        public string stopThreshold
        {
            get { return _stopThreshold; }
            set { _stopThreshold = value; }
        }

        internal bool _FWSWT5;
        public bool FWSWT5
        {
            get { return _FWSWT5; }
            set { _FWSWT5 = value; }
        }

        internal bool _overwrite;
        public bool overwrite
        {
            get { return _overwrite; }
            set { _overwrite = value; }
        }

        public void Save(ProgramSettings settings)
        {
            XmlSerializer writeSerializer = new XmlSerializer(typeof(ProgramSettings));
            StreamWriter writeStream = new StreamWriter(Directory.GetCurrentDirectory() + "\\settings\\settings.xml");
            writeSerializer.Serialize(writeStream, settings);
            writeStream.Close();
        }

        public void Load(ref ProgramSettings settings)
        {
            XmlSerializer readSerializer = new XmlSerializer(typeof(ProgramSettings));
            FileStream readStream = new FileStream(Directory.GetCurrentDirectory() + "\\settings\\settings.xml", FileMode.Open);
            settings = (ProgramSettings)readSerializer.Deserialize(readStream);
            readStream.Close();
        }
    }
}
