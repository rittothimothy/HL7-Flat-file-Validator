using System;
using System.IO;
using System.Reflection;
using DTO;
using System.Xml;
using System.Collections.Generic;
using static UtilityServices.Enums;
using System.Linq;

namespace UtilityServices
{
    public static class Utility
    {
        public static string getCurrenExecutingAssemblyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
        public static MessageDTO getADTXMLConfig(string XMLFileName)
        {
            MessageDTO _MessageDTO = new MessageDTO();
            string current_executing_path = Utility.getCurrenExecutingAssemblyPath();
            string XMLConfigPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(current_executing_path).FullName).FullName).FullName;
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLConfigPath+ "/" + XMLFileName +".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ADT_A04");
            _MessageDTO.Segments = new List<MessageSegment>();
            _MessageDTO.MessageCode = MessageCodes.ADT04_AO4.ToString();
            foreach (XmlNode segment in node.ChildNodes)
            {
                MessageSegment _MessageSegment = new MessageSegment();
                _MessageSegment.IsRequired = Convert.ToBoolean(segment.Attributes["required"]?.InnerText);
                _MessageSegment.SegmentCode = segment.Name;
                _MessageSegment.IsRepeatable = Convert.ToBoolean(segment.Attributes["repeatability"]?.InnerText);
                _MessageDTO.Segments.Add(_MessageSegment);
            }
            return _MessageDTO;
        }
        public static bool ValidateHL7FlatFile(MessageDTO _MessageDTO)
        {
            _MessageDTO = UpdateSegmentCount(_MessageDTO);
            bool IsValid = ValidateSegments(_MessageDTO);
            return IsValid;
        }
        public static bool ValidateSegments(MessageDTO _MessageDTO)
        {
            bool IsValid = true;
            foreach (MessageSegment _MessageSegment in _MessageDTO.Segments)
            {
                // Validation for required
                if (_MessageSegment.IsRequired == true)
                {
                    if (_MessageSegment.Count < 1)
                    {
                        Console.WriteLine("Required validation failed for segment " + _MessageSegment.SegmentCode+"\nNo segment with name "+_MessageSegment.SegmentCode);
                        IsValid = false;
                        break;
                    }
                }
                // Validation for repeatable
                if (!_MessageSegment.IsRepeatable)
                {
                    if (_MessageSegment.Count > 1)
                    {
                        Console.WriteLine("Repeatable validation failed for segment " + _MessageSegment.SegmentCode + "\n" + _MessageSegment.SegmentCode + " segment appeared more than once.");
                        IsValid = false;
                        break;
                    }
                }
            }

            return IsValid;
        }
        public static MessageDTO UpdateSegmentCount(MessageDTO _MessageDTO)
        {
            string current_executing_path = Utility.getCurrenExecutingAssemblyPath();
            string HL7FlatFileInputLocation = Directory.GetParent(Directory.GetParent(Directory.GetParent(current_executing_path).FullName).FullName).FullName+"/"+ Constants.HL7FileInputLocation+"/"+Constants.HL7FileName +".txt";
            // Read file using StreamReader. Reads file line by line    
            using (StreamReader file = new StreamReader(HL7FlatFileInputLocation))
            {
                string ln;
                char[] separators = new char[] { '|' };

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln != "") // Ignore empty lines in flat file
                    {
                        string[] subs = ln.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        int count = 0;
                        if (_MessageDTO.Segments.Where(t => t.SegmentCode == subs[0]).FirstOrDefault() != null)
                        {
                            count = _MessageDTO.Segments.Where(t => t.SegmentCode == subs[0]).FirstOrDefault().Count;
                            _MessageDTO.Segments.Where(t => t.SegmentCode == subs[0]).FirstOrDefault().Count = ++count;
                            //Console.WriteLine(subs[0] + ":" + _MessageDTO.Segments.Where(t => t.SegmentCode == subs[0]).FirstOrDefault().Count);
                        }
                    }
                }
                file.Close();
                return _MessageDTO;

            }
            
        }
    }
}
