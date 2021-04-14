using System;
using ServiceFactory;
using DTO;
using UtilityServices;

namespace HL7_Flat_file_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadInitialScreen();
            Console.ReadLine();

        }
        public static void LoadInitialScreen()
        {
            Console.WriteLine("####################################################\n Validation Tool for HL7 v2.8 \n#################################################### \n1. Validate HL7 Flat File \n2. Process HL7 Flat File\n3. Exit \nType your choice( 1/2/3): ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ValidateHL7FlatFile();
                    break;
                case 2:
                    ProcessHL7FlatFile();
                    break;
                case 3:
                    Console.WriteLine("Press enter to exit.");
                    break;
                default:
                    LoadInitialScreen();
                    break;
            }
        }
        public static void ValidateHL7FlatFile()
        {
            MessageDTO _MessageDTO = new MessageDTO();
            var obj = FactoryService.GetHL7ValidationServiceInstance();
            _MessageDTO = obj.getHL7ValidationConfig();
            bool IsValid = Utility.ValidateHL7FlatFile(_MessageDTO);
            if (IsValid)
            {
                Console.WriteLine("HL7 Flat file is valid and complies" +
                    " HL7 v2.8 standard.");
                Console.WriteLine("Do you want to list the valid segments & no of occurrences (Y/N)? ");
                char choice =Convert.ToChar( Console.Read());
                if (choice.ToString().ToUpper() == "Y")
                {
                    foreach (MessageSegment MsgSegment in _MessageDTO.Segments)
                    {
                        Console.WriteLine(MsgSegment.SegmentCode + ": " + MsgSegment.Count);

                    }
                }
                Console.ReadLine();
                Console.WriteLine("Press enter to exit.");
            }
            else
            {
                Console.WriteLine("HL7 Flat file is not valid" +
                    " HL7 v2.8 standard.");
                Console.ReadLine();
                Console.WriteLine("Press enter to exit.");
            }
        }
        public static void ProcessHL7FlatFile()
        {
            //Parsing HL7 message not yet implemented.Raising Exception on method invoking.
            Console.WriteLine("HL7 Message Parsing is not yet implemented!\nPlease choose a different option!");
            LoadInitialScreen();
            //throw new NotImplementedException();
        }
    }
}
