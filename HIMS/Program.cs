using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace HIMS
{
    class Program
    {
        static List<Physician> physicians = new List<Physician>()
        {
            //Seed data
            // new Physician
            // { Id = 1, FirstName = "FirstName", MiddleName = "MiddleName", BirthDate = DateTime.Now, Gender = "M", LastName = "Last Name", Height = 171, Weight=50,
            // ContactInfo = new List<ContactInfo>() { new ContactInfo { PhysicianId = 1, HomeAddress = "Home", HomePhone = "1234"
            // } } , Specialization = new List<Specialization>() { new Specialization { PhysicianId = 1, Name = "Optalmologist", Description = "descibe" } }

            //  }
        };

        static void Main(string[] args)
        {


            var whileRunning = true;

            while (whileRunning)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine("Welcome to Pointwest Hospital Information Management System");
                Console.WriteLine("============================================================");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Physician Records");
                Console.WriteLine("2. Delete Physician Records");
                Console.WriteLine("3. Update Physician Records");
                Console.WriteLine("4. View All Physician Records");
                Console.WriteLine("5. Find a Physician by Id");
                Console.WriteLine("6. Clear Screen");
                Console.WriteLine("7. Exit");



                Console.Write("Please Select on the Menu then click Enter: ");



                var selected = selectMenu();

                switch (selected)
                {
                    case "1":

                        AddPhysician();
                        Console.Clear();
                        break;


                    case "2":

                        DeleteRecord();
                        Console.Clear();
                        break;

                    case "3":
                        UpdatePhysician();
                        break;

                    case "4":
                        Console.Clear();
                        ViewAllPhysician();
                        whileRunning = true;
                        break;

                    case "5":
                        GetPhysicianById();
                        break;

                    case "6":
                        
                        Console.Clear();
                        Console.ReadLine();
                        Console.Clear();
                        whileRunning = true;
                        break;

                    case "7":
                        Console.Clear();
                        whileRunning = false;
                        break;




                }

            }
        }




        private static string selectMenu()
        {

            string[] menu = { "1", "2", "3", "4", "5", "6", "7" };
            var menuSelected = ReusableMethod.inputNumericValue("Menu", 1);
            int index = Array.IndexOf(menu, menuSelected.ToString());
            bool isMenuSelected = (index > -1);

            while (!isMenuSelected)
            {
                ReusableMethod.incorrectInput("Please select existing menu: ");
                var newMenuSelected = ReusableMethod.inputNumericValue("Menu", 1);
                int newIndex = Array.IndexOf(menu, newMenuSelected.ToString());

                if (newIndex > -1)
                    return newMenuSelected.ToString();
                else
                    isMenuSelected = false;
            }

            return menuSelected.ToString();
        }

        private static void AddPhysician()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("______________________________Add Physician_____________________________");

                Console.WriteLine("________________________________________________________________________");

                Physician input = new Physician();
                ContactInfo contactInfo = new ContactInfo();
                Specialization specialization = new Specialization();
                if (physicians.Count > 0)
                {
                    input.Id = physicians.Last().Id + 1;
                }

                else
                {
                    input.Id = 1;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Personal Information");
                Console.ResetColor();

                // Input First Name

                Console.Write("First Name: ");
                bool isFirstname = false;
                while (!isFirstname)
                {
                    input.FirstName = ReusableMethod.inputLengthMax(20);
                    isFirstname = ReusableMethod.isNotEmpty("First Name", input.FirstName);
                }
                ReusableMethod.correctInput("First Name: " + input.FirstName);

                // Input Middle Name
                Console.Write("\nMiddle Name: ");
                bool isMiddlename = false;
                while (!isMiddlename)
                {
                    input.MiddleName = ReusableMethod.inputLengthMax(20);
                    isMiddlename = ReusableMethod.isNotEmpty("Middle Name", input.MiddleName);
                }
                ReusableMethod.correctInput("Middle Name: " + input.MiddleName);

                // Input Last Name
                Console.Write("\nLast Name: ");
                bool isLastName = false;
                while (!isLastName)
                {
                    input.LastName = ReusableMethod.inputLengthMax(20);
                    isLastName = ReusableMethod.isNotEmpty("Last Name", input.LastName);
                }
                ReusableMethod.correctInput("Last Name: " + input.LastName);

                // Input BirthDate
                Console.Write("\nBirthDate (MM/DD/YYYY): ");
                string date = ReusableMethod.inputLengthMax(20);
                DateTime dt;
                while (!DateTime.TryParseExact(date, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    ReusableMethod.incorrectInput("Incorrect BirthDate Format. Enter BirthDate(MM/DD/YYYY): ");
                    date = ReusableMethod.inputLengthMax(20);
                }
                ReusableMethod.correctInput("BirthDate: " + date);
                input.BirthDate = Convert.ToDateTime(date);

                // Input Gender
                Console.Write("\nGender (M/F): ");
                bool isGenderValid = false;
                while (!isGenderValid)
                {
                    input.Gender = ReusableMethod.inputLengthMax(1).ToUpper();

                    if (input.Gender == "M")
                    {
                        isGenderValid = true;
                    }
                    else if (input.Gender == "F")
                    {
                        isGenderValid = true;
                    }
                    else
                    {
                        ReusableMethod.incorrectInput("Please enter M/F. Gender: ");
                    }

                }
                ReusableMethod.correctInput("Gender: " + input.Gender);

                // Input Weight
                Console.Write("\nWeight: ");
                input.Weight = ReusableMethod.inputNumericValue("Weight", 5);
                ReusableMethod.correctInput("Weight: " + input.Weight);

                // Input Height
                Console.Write("\nHeight: ");
                input.Height = ReusableMethod.inputNumericValue("Height", 5);
                ReusableMethod.correctInput("Height: " + input.Height);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nContact Information");
                Console.ResetColor();

                // Input Home Address
                Console.Write("\nHome Address: ");
                bool homeAddLength = false;
                while (!homeAddLength)
                {
                    contactInfo.HomeAddress = ReusableMethod.inputLengthMax(40);
                    homeAddLength = ReusableMethod.isNotEmpty("Home Address", contactInfo.HomeAddress);
                }
                ReusableMethod.correctInput("Home Address: " + contactInfo.HomeAddress);

                // Input Home Phone
                Console.Write("\nHome Phone: ");
                contactInfo.HomePhone = ReusableMethod.inputNumericValue("Home Phone", 11);
                ReusableMethod.correctInput("Home Phone: " + contactInfo.HomePhone);

                // Input Office Address
                Console.Write("\nOffice Address: ");
                bool officeAddLength = false;
                while (!officeAddLength)
                {
                    contactInfo.OfficeAddress = ReusableMethod.inputLengthMax(40);
                    officeAddLength = ReusableMethod.isNotEmpty("Office Address", contactInfo.OfficeAddress);
                }
                ReusableMethod.correctInput("Office Address: " + contactInfo.OfficeAddress);

                // Input Office Phone
                Console.Write("\nOffice Phone: ");
                contactInfo.OfficePhone = ReusableMethod.inputNumericValue("Office Phone", 11);
                ReusableMethod.correctInput("Office Phone: " + contactInfo.OfficePhone);

                // Input E-mail
                Console.Write("\nE-mail Address: ");
                bool isValidEmail = false;

                while (!isValidEmail)
                {

                    try
                    {
                        var email = ReusableMethod.inputLengthMax(20);
                        if (!ReusableMethod.isNotEmpty("Email", email))
                        {
                            isValidEmail = false;

                        }
                        else
                        {
                            contactInfo.EmailAddress = email;
                            var addr = new System.Net.Mail.MailAddress(email);
                            isValidEmail = true;
                        }
                    }
                    catch (FormatException)
                    {
                        ReusableMethod.incorrectInput("Input valid Email Format: ");
                    }
                }
                ReusableMethod.correctInput("Email: " + contactInfo.EmailAddress);

                // Input Cellphone Number
                Console.Write("\nCellphone Number: ");
                contactInfo.CellphoneNumber = ReusableMethod.inputNumericValue("Cellphone Number", 11);
                ReusableMethod.correctInput("Cellphone Number: " + contactInfo.CellphoneNumber);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nSpecialization\n");
                Console.ResetColor();

                // Input Name
                Console.Write("Name: ");

                bool specNameLength = false;
                while (!specNameLength)
                {
                    specialization.Name = ReusableMethod.inputLengthMax(20);
                    specNameLength = ReusableMethod.isNotEmpty("Specialization Name", specialization.Name);
                }
                ReusableMethod.correctInput("Name: " + specialization.Name);

                // Input Dsscription
                Console.Write("\nDescription: ");
                bool specDescLength = false;
                while (!specDescLength)
                {
                    specialization.Description = ReusableMethod.inputLengthMax(100);
                    specDescLength = ReusableMethod.isNotEmpty("Specialization Description", specialization.Description);
                }
                ReusableMethod.correctInput("Description: " + specialization.Description);

                AddRecord(input, contactInfo, specialization);
                ViewPhysicianPersonalInfo(input.Id.ToString());
                ViewPhysicianContactInfo(input.Id.ToString());
                ViewPhysicianSpecialization(input.Id.ToString());


                Console.Write("Do you want to add another physician (Y/N): ");
                bool validSelect = false;
                while (!validSelect)
                {
                    var select = ReusableMethod.inputLengthMax(1).ToUpper();

                    switch (select)
                    {
                        case "Y":
                            validSelect = true;
                            Console.Clear();
                            AddPhysician();
                            break;


                        case "N":
                            validSelect = true;
                            Console.Clear();
                            Main(null);
                            break;

                        default:
                            ReusableMethod.incorrectInput("Please input 'Y' to add another Physician or 'N' to go back to Main Menu : ");
                            break;
                    }
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - AddPhysician");

            }

        }

        private static void AddRecord(Physician physician, ContactInfo contactInfo, Specialization specialization)

        {
            try
            {
                Physician phys = new Physician();
                ContactInfo cont = new ContactInfo();

                phys.Id = physician.Id;
                phys.FirstName = physician.FirstName;
                phys.MiddleName = physician.MiddleName;
                phys.LastName = physician.LastName;
                phys.BirthDate = physician.BirthDate;
                phys.Gender = physician.Gender;
                phys.Height = physician.Height;
                phys.Weight = physician.Weight;
                phys.ContactInfo = new List<ContactInfo> { new ContactInfo { PhysicianId = physician.Id,
                HomeAddress = contactInfo.HomeAddress, HomePhone = contactInfo.HomePhone,
                OfficeAddress = contactInfo.OfficeAddress, OfficePhone = contactInfo.OfficePhone,
                EmailAddress = contactInfo.EmailAddress, CellphoneNumber = contactInfo.CellphoneNumber} };
                phys.Specialization = new List<Specialization> {  new Specialization { PhysicianId = physician.Id,
                Name = specialization.Name, Description = specialization.Description} };
                physicians.Add(phys);
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - AddRecord");

            }
        }

        private static void ViewAllPhysician()
        {
            try
            {


                Console.WriteLine("Please select physician information:");
                Console.WriteLine("1. Personal Information");
                Console.WriteLine("2. Contact Information");
                Console.WriteLine("3. Specialization");
                Console.Write("Select from options above: ");
                bool isExisting = false;
                while (!isExisting)

                {
                    var selectedPhysicianInformation = ReusableMethod.inputNumericValue("Physician Information Menu", 1);
                    switch (selectedPhysicianInformation.ToString())
                    {
                        case "1":

                            ViewPhysicianPersonalInfo("All");
                            Console.WriteLine("Please click Enter to go back to Main Menu");
                            Console.ReadLine();
                            isExisting = true;
                            break;

                        case "2":
                            ViewPhysicianContactInfo("All");
                            Console.WriteLine("Please click Enter to go back to Main Menu");
                            Console.ReadLine();
                            isExisting = true;
                            break;

                        case "3":
                            ViewPhysicianSpecialization("All");
                            Console.WriteLine("Please click Enter to go back to Main Menu");
                            Console.ReadLine();
                            isExisting = true;
                            break;

                        default:
                            ReusableMethod.incorrectInput("Please select from options above: ");
                            break;

                    }
                }


                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - ViewAllPhysician");

            }

        }

        private static void ViewPhysicianPersonalInfo(string targetPhysician)
        {
            try
            {


                Console.Clear();
                Console.WriteLine("List Of Physicians - Personal Information");
                Console.WriteLine("_________________________________________________________________________________________________________");

                Console.WriteLine("Id   First Name            Middle Name           Last Name             BirthDate  Gender   Weight  Height");

                Console.WriteLine("_________________________________________________________________________________________________________");
                string targetPhys = targetPhysician;
                List<Physician> selectedPhys = new List<Physician>();
                if (targetPhys == "All")
                {
                    selectedPhys = physicians;
                }
                else
                {

                    selectedPhys = physicians.Where(x => x.Id == Convert.ToInt32(targetPhys)).ToList();
                }


                foreach (var item in selectedPhys)
                {
                    Console.Write("{0,-5}", item.Id);

                    string firstName = ReusableMethod.UppercaseFirst(item.FirstName);
                    Console.Write("{0,-22}", firstName);

                    string middleName = ReusableMethod.UppercaseFirst(item.MiddleName);
                    Console.Write("{0,-22}", middleName);

                    string lastName = ReusableMethod.UppercaseFirst(item.LastName);
                    Console.Write("{0,-22}", lastName);

                    Console.Write("{0,-14}", item.BirthDate.ToShortDateString());

                    Console.Write("{0,-6}", item.Gender);

                    Console.Write("{0,-8}", item.Weight);

                    Console.Write("{0,-8}", item.Height);
                    Console.WriteLine();


                }
                Console.WriteLine("_________________________________________________________________________________________________________");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - ViewPhysicianPersonalInfo");

            }

        }
        private static void ViewPhysicianContactInfo(string targetPhysician)
        {
            try
            {


                Console.Clear();
                Console.WriteLine("List Of Physicians - Contact Information");
                Console.WriteLine("____________________________________________________________________________________________________________________________________________________");

                Console.WriteLine("Id Home Address                              Home Phone   Office Address                            Office Phone E-mail Address        Cellphone No.");

                Console.WriteLine("____________________________________________________________________________________________________________________________________________________");
                string targetPhys = targetPhysician;
                List<Physician> selectedPhys = new List<Physician>();
                if (targetPhys == "All")
                {
                    selectedPhys = physicians;
                }
                else
                {

                    selectedPhys = physicians.Where(x => x.Id == Convert.ToInt32(targetPhys)).ToList();
                }
                foreach (var item in selectedPhys)
                {
                    Console.Write("{0,-3}", item.Id);

                    Console.Write("{0,-42}", item.ContactInfo.Select(y => y.HomeAddress).First());

                    Console.Write("{0,-13}", item.ContactInfo.Select(y => y.HomePhone).First());

                    Console.Write("{0,-42}", item.ContactInfo.Select(y => y.OfficeAddress).First());

                    Console.Write("{0,-13}", item.ContactInfo.Select(y => y.OfficePhone).First());

                    Console.Write("{0,-22}", item.ContactInfo.Select(y => y.EmailAddress).First());

                    Console.Write("{0,-13}", item.ContactInfo.Select(y => y.CellphoneNumber).First());
                    Console.WriteLine();

                }
                Console.WriteLine("____________________________________________________________________________________________________________________________________________________");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - ViewPhysicianContactInfo");

            }
        }

        private static void ViewPhysicianSpecialization(string targetPhysician)
        {
            try
            {


                Console.Clear();
                Console.WriteLine("List Of Physicians - Specialization");
                Console.WriteLine("_____________________________________________________________________________________________________________________________");

                Console.WriteLine("Id Specialization Name   Specialization Description  ");

                Console.WriteLine("_____________________________________________________________________________________________________________________________");
                string targetPhys = targetPhysician;
                List<Physician> selectedPhys = new List<Physician>();
                if (targetPhys == "All")
                {
                    selectedPhys = physicians;
                }
                else
                {

                    selectedPhys = physicians.Where(x => x.Id == Convert.ToInt32(targetPhys)).ToList();
                }
                foreach (var item in selectedPhys)
                {
                    Console.Write("{0,-3}", item.Id);

                    Console.Write("{0,-22}", item.Specialization.Select(y => y.Name).First());

                    Console.Write("{0,-50}", item.Specialization.Select(y => y.Description).First());

                    Console.WriteLine();

                }
                Console.WriteLine("_____________________________________________________________________________________________________________________________");
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - ViewphysicianSpecializationInfo");

            }
        }

        public static void DeleteRecord()
        {
            try
            {


                Console.Clear();
                Console.WriteLine("___________________________Delete Physician___________________________");
                Console.WriteLine("______________________________________________________________________");
                bool physId = false;
                while (!physId)
                {
                    if (!physicians.Any())
                    {
                        Console.Write("No physician record. Press Enter to go back to Main Menu");
                        Console.ReadLine();
                        physId = true;
                    }
                    else
                    {
                        Console.Write("Id of Physician wish to delete (Press Enter to go back to Main Menu): ");
                        var physicianId = ReusableMethod.inputId("Physician Id", 8);
                        if (physicianId == String.Empty)
                        {
                            Console.Clear();
                            Main(null);
                        }
                        else if (!physicians.Any(phys => phys.Id == Convert.ToInt32(physicianId)))
                        {
                            bool isExist = false;
                            while (!isExist)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                ReusableMethod.incorrectInput("Please input existing Physician Id (Press Enter to go back to Main Menu): ");
                                Console.ResetColor();

                                var newPhysicianId = ReusableMethod.inputId("Physician Id", 1);
                                if (newPhysicianId == String.Empty)
                                {
                                    Console.Clear();
                                    Main(null);
                                }
                                else if (physicians.Any(phys => phys.Id == Convert.ToInt32(newPhysicianId)))
                                {
                                    physicians.RemoveAll(phys => phys.Id == Convert.ToInt32(newPhysicianId));
                                    ReusableMethod.correctInput("Successfully Deleted. Press Enter to go back to Main Menu");
                                    Console.ReadLine();
                                    isExist = true;
                                    physId = true;
                                }
                            }
                        }
                        else
                        {
                            ReusableMethod.correctInput("Successfully Deleted. Press Enter to go back to Main Menu");
                            Console.ReadLine();
                            physicians.RemoveAll(phys => phys.Id == Convert.ToInt32(physicianId));
                            physId = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - DeleteRecord");

            }
        }
        private static void UpdatePhysician()

        {
            try
            {


                Console.Clear();
                Console.WriteLine("____________________________Edit Physician____________________________");
                Console.WriteLine("______________________________________________________________________");

                if (!physicians.Any())
                {
                    Console.Write("No physician record. Press Enter to go back to Main Menu");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {

                    Console.Write("Enter Physician Id (Press Enter to Exit): ");
                    var id = ReusableMethod.inputId("Physician Id", 8);
                    ReusableMethod.correctInput("Selected Physician Info: " + id);
                    if (id == String.Empty)
                    {
                        Console.Clear();
                        Main(null);
                    }
                    else
                    {

                        List<Physician> selectedPhysician = new List<Physician>();
                        selectedPhysician = physicians.Where(x => x.Id == Convert.ToInt32(id)).ToList();
                        if (selectedPhysician.Count > 0)
                        {
                            foreach (var item in selectedPhysician)
                            {

                                Console.WriteLine("\n1. Personal Info");
                                Console.WriteLine("2. Contact Info");
                                Console.WriteLine("3. Specialization");
                                Console.Write("Please Select Information to Update:");
                                bool isPhysInfoMenu = false;
                                while (!isPhysInfoMenu)
                                {
                                    var selectedInfo = ReusableMethod.inputNumericValue("Physician Info Menu", 1);
                                    ReusableMethod.correctInput("Selected Physician Info: " + selectedInfo.ToString());
                                    switch (selectedInfo.ToString())
                                    {
                                        case "1":
                                            Console.WriteLine("\n1. First Name");
                                            Console.WriteLine("2. Middle Name");
                                            Console.WriteLine("3. Last Name");
                                            Console.WriteLine("4. Birthdate");
                                            Console.WriteLine("5. Gender");
                                            Console.WriteLine("6. Weight");
                                            Console.WriteLine("7. Height");
                                            Console.Write("Please Select Personal Information to Update:");
                                            isPhysInfoMenu = true;

                                            bool isPhysPersonalInfoMenu = false;
                                            while (!isPhysPersonalInfoMenu)
                                            {
                                                var selectedPersonalInfo = ReusableMethod.inputNumericValue("Physician Personal Info Menu", 1);
                                                ReusableMethod.correctInput("Selected Physician's Personal Info: " + selectedPersonalInfo.ToString());
                                                switch (selectedPersonalInfo.ToString())
                                                {


                                                    case "1":
                                                        Console.WriteLine("\nNew First Name: ");

                                                        bool isFirstname = false;
                                                        while (!isFirstname)
                                                        {
                                                            item.FirstName = ReusableMethod.inputLengthMax(20);
                                                            isFirstname = ReusableMethod.isNotEmpty("First Name", item.FirstName);
                                                        }
                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    case "2":
                                                        Console.WriteLine("\nNew Middle Name: ");
                                                        bool isMiddlename = false;
                                                        while (!isMiddlename)
                                                        {
                                                            item.MiddleName = ReusableMethod.inputLengthMax(20);
                                                            isMiddlename = ReusableMethod.isNotEmpty("First Name", item.MiddleName);
                                                        }

                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    case "3":
                                                        Console.WriteLine("\nNew Last Name: ");
                                                        bool isLastname = false;
                                                        while (!isLastname)
                                                        {
                                                            item.LastName = ReusableMethod.inputLengthMax(20);
                                                            isLastname = ReusableMethod.isNotEmpty("First Name", item.LastName);
                                                        }

                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    case "4":

                                                        Console.WriteLine("\nNew Birthdate: ");
                                                        string date = ReusableMethod.inputLengthMax(20);
                                                        DateTime dt;
                                                        while (!DateTime.TryParseExact(date, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                                                        {
                                                            ReusableMethod.incorrectInput("Incorrect BirthDate Format. Enter BirthDate(MM/DD/YYYY): ");
                                                            date = ReusableMethod.inputLengthMax(20);
                                                        }
                                                        item.BirthDate = Convert.ToDateTime(date);
                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    case "5":

                                                        Console.WriteLine("\nGender: ");
                                                        bool isGenderValid = false;
                                                        while (!isGenderValid)
                                                        {
                                                            item.Gender = ReusableMethod.inputLengthMax(1).ToUpper();
                                                            //Console.ReadLine().ToUpper();
                                                            if (item.Gender == "M")
                                                            {
                                                                isGenderValid = true;
                                                            }
                                                            else if (item.Gender == "F")
                                                            {
                                                                isGenderValid = true;
                                                            }
                                                            else
                                                            {
                                                                ReusableMethod.incorrectInput("Please enter M/F. Gender: ");
                                                            }

                                                        }

                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    case "6":

                                                        Console.WriteLine("\nEnter New Weight: ");
                                                        item.Weight = ReusableMethod.inputNumericValue("Weight", 5);
                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    case "7":

                                                        Console.WriteLine("\nEnter New Height: ");
                                                        item.Height = ReusableMethod.inputNumericValue("Height", 5);
                                                        ViewPhysicianPersonalInfo(id.ToString());
                                                        isPhysPersonalInfoMenu = true;
                                                        break;

                                                    default:
                                                        ReusableMethod.incorrectInput("Please select from options above: ");
                                                        break;
                                                }

                                            }
                                            break;

                                        case "2":
                                            Console.WriteLine("\n1. Home Address");
                                            Console.WriteLine("2. Home Phone");
                                            Console.WriteLine("3. Office Address");
                                            Console.WriteLine("4. Office Phone");
                                            Console.WriteLine("5. e-Mail Address");
                                            Console.WriteLine("6. Cellphone Number");
                                            Console.Write("Please Select Contact Information to Update:");
                                            isPhysInfoMenu = true;

                                            bool isPhysContactInfoMenu = false;
                                            while (!isPhysContactInfoMenu)
                                            {
                                                var selectedContactInfo = ReusableMethod.inputNumericValue("Physician Contact Info Menu", 1);
                                                ReusableMethod.correctInput("Selected Physician's Contact Info: " + selectedContactInfo.ToString());

                                                switch (selectedContactInfo.ToString())
                                                {
                                                    case "1":
                                                        Console.WriteLine("\nHome Address: ");
                                                        var homeAddress = "";
                                                        bool homeAddLength = false;
                                                        while (!homeAddLength)
                                                        {
                                                            homeAddress = ReusableMethod.inputLengthMax(40);
                                                            homeAddLength = ReusableMethod.isNotEmpty("Home Address", homeAddress);
                                                        }
                                                        item.ContactInfo.ForEach(x => x.HomeAddress = homeAddress);
                                                        ViewPhysicianContactInfo(id.ToString());
                                                        isPhysContactInfoMenu = true;
                                                        break;

                                                    case "2":
                                                        Console.WriteLine("\nHome Phone: ");
                                                        item.ContactInfo.ForEach(x => x.HomePhone = ReusableMethod.inputNumericValue("Home Phone", 11));
                                                        ViewPhysicianContactInfo(id.ToString());
                                                        isPhysContactInfoMenu = true;
                                                        break;

                                                    case "3":
                                                        Console.WriteLine("\nOffice Address: ");
                                                        var officeAddress = "";
                                                        bool officeAddNotEmpty = false;
                                                        while (!officeAddNotEmpty)
                                                        {
                                                            officeAddress = ReusableMethod.inputLengthMax(40);
                                                            officeAddNotEmpty = ReusableMethod.isNotEmpty("Office Address", officeAddress);
                                                        }

                                                        item.ContactInfo.ForEach(x => x.OfficeAddress = officeAddress);
                                                        ViewPhysicianContactInfo(id.ToString());
                                                        isPhysContactInfoMenu = true;
                                                        break;

                                                    case "4":
                                                        Console.WriteLine("\nOffice Phone: ");
                                                        item.ContactInfo.ForEach(x => x.OfficePhone = ReusableMethod.inputNumericValue("Office Phone", 11));
                                                        ViewPhysicianContactInfo(id.ToString());
                                                        isPhysContactInfoMenu = true;
                                                        break;

                                                    case "5":
                                                        Console.WriteLine("\ne-Mail Address: ");
                                                        var email = "";
                                                        bool isValidEmail = false;
                                                        while (!isValidEmail)
                                                        {
                                                            try
                                                            {
                                                                email = ReusableMethod.inputLengthMax(20);
                                                                if (!ReusableMethod.isNotEmpty("Email", email))
                                                                {
                                                                    isValidEmail = false;

                                                                }
                                                                else
                                                                {
                                                                    var addr = new System.Net.Mail.MailAddress(email);
                                                                    isValidEmail = true;
                                                                }
                                                            }
                                                            catch (FormatException)
                                                            {
                                                                ReusableMethod.incorrectInput("Input valid Email Format: ");
                                                            }
                                                        }
                                                        item.ContactInfo.ForEach(x => x.EmailAddress = email);
                                                        ViewPhysicianContactInfo(id.ToString());
                                                        isPhysContactInfoMenu = true;
                                                        break;

                                                    case "6":
                                                        Console.Write("\nCellphone Number: ");
                                                        item.ContactInfo.ForEach(x => x.CellphoneNumber = ReusableMethod.inputNumericValue("Cellphone Phone", 11));
                                                        ViewPhysicianContactInfo(id.ToString());
                                                        isPhysContactInfoMenu = true;
                                                        break;

                                                    default:
                                                        ReusableMethod.incorrectInput("Please select from options above: ");
                                                        break;

                                                }
                                            }
                                            break;




                                        case "3":
                                            Console.WriteLine("\n1. Name");
                                            Console.WriteLine("2. Description");
                                            Console.Write("Please Select Specialization Info to Update:");
                                            isPhysInfoMenu = true;

                                            bool isPhysSpecInfoMenu = false;
                                            while (!isPhysSpecInfoMenu)
                                            {
                                                var selectedSpecialization = ReusableMethod.inputNumericValue("Physician Specialization Menu", 1);
                                                ReusableMethod.correctInput("Selected Physician's Specialization: " + selectedSpecialization.ToString());

                                                switch (selectedSpecialization.ToString())
                                                {
                                                    case "1":
                                                        Console.WriteLine("\nName: ");
                                                        var specName = "";
                                                        bool specNameNotEmpty = false;
                                                        while (!specNameNotEmpty)
                                                        {
                                                            specName = ReusableMethod.inputLengthMax(20);
                                                            specNameNotEmpty = ReusableMethod.isNotEmpty("Home Address", specName);
                                                        }

                                                        item.Specialization.ForEach(x => x.Name = specName);
                                                        ViewPhysicianSpecialization(id.ToString());
                                                        isPhysSpecInfoMenu = true;
                                                        break;

                                                    case "2":
                                                        Console.WriteLine("\nDescription: ");
                                                        var specDescription = "";
                                                        bool specDescNotEmpty = false;
                                                        while (!specDescNotEmpty)
                                                        {
                                                            specDescription = ReusableMethod.inputLengthMax(100);
                                                            specDescNotEmpty = ReusableMethod.isNotEmpty("Home Address", specDescription);
                                                        }

                                                        item.Specialization.ForEach(x => x.Description = specDescription);
                                                        ViewPhysicianSpecialization(id.ToString());
                                                        isPhysSpecInfoMenu = true;
                                                        break;

                                                    default:
                                                        ReusableMethod.incorrectInput("Please select from options above: ");
                                                        break;
                                                }

                                            }
                                            break;


                                        default:
                                            ReusableMethod.incorrectInput("Please select from options above: ");
                                            break;

                                    }
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("\n_______________________No Physician Available_________________________");
                            Console.WriteLine("______________________________________________________________________");
                            Console.Write("Press Enter to Exit");
                            Console.ReadLine();
                            Console.Clear();
                        }

                    }

                }

               Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - UpdatePhysician");

            }
        }
        private static void GetPhysicianById()

        {
            try
            {


                Console.Clear();
                Console.WriteLine("___________________________Find Physician_____________________________");
                Console.WriteLine("______________________________________________________________________");
                if (!physicians.Any())
                {
                    Console.Write("No physician record. Press Enter to go back to Main Menu");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {

                    Console.Write("Enter Physician Id (Press Enter to go back to Main Menu): ");
                    var id = ReusableMethod.inputId("Physician Id", 8);
                    if (id == String.Empty)
                    {
                        Console.Clear();
                        Main(null);
                    }
                    else
                    {
                        if (physicians.Count > 0)
                        {
                            ViewPhysicianPersonalInfo(id.ToString());
                            ViewPhysicianContactInfo(id.ToString());
                            ViewPhysicianSpecialization(id.ToString());

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("________________________No Physician Found!___________________________");
                            Console.ReadLine();
                        }
                    }
                }
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - GetPhysicianById");

            }
        }

    }
    public class Physician
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public List<ContactInfo> ContactInfo { get; set; }
        public List<Specialization> Specialization { get; set; }


    }

    public class ContactInfo
    {
        public int PhysicianId { get; set; }
        public string HomeAddress { get; set; }
        public double HomePhone { get; set; }
        public string OfficeAddress { get; set; }
        public double OfficePhone { get; set; }
        public string EmailAddress { get; set; }
        public double CellphoneNumber { get; set; }

    }
    public class Specialization
    {
        public int PhysicianId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class ReusableMethod
    {


        public static bool isNotEmpty(string info, string input)
        {


            if (input.Length <= 0)
            {
                incorrectInput(info + " is required. Enter " + info + ": ");
                return false;
            }
            return true;


        }

        public static void incorrectInput(string message)
        {
            try
            {


                Console.SetCursorPosition(0, Console.CursorTop - 0);
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(message);
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong - incorrectInput");

            }
        }

        public static void correctInput(string message)
        {



            Console.SetCursorPosition(0, Console.CursorTop - 0);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(message);
            Console.ResetColor();

        }

        public static string UppercaseFirst(string text)
        {
            string upperCaseFirst = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return upperCaseFirst;
        }

        public static string inputLengthMax(int limit)
        {


            string str = string.Empty;
            while (true)
            {
                char c = Console.ReadKey(true).KeyChar;
                if (c == '\r')
                {
                    break;

                }
                else if (c == '\b')
                {
                    if (str != "")
                    {
                        str = str.Substring(0, str.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (str.Length < limit)
                {
                    Console.Write(c);
                    str += c;

                }


            }

            return str;

        }
        public static double inputNumericValue(string info, int numberOfChar)
        {
            double input = 0;
            bool isDecimalAllowed = (info == "Height") || (info == "Weight");
            bool isNumeric = false;
            while (!isNumeric)
            {
                var strNumber = inputLengthMax(numberOfChar);
                if (isNotEmpty(info, strNumber))
                {
                    bool inputFormat = double.TryParse(strNumber, out input);
                    if (inputFormat)
                    {
                        if (input < 0)
                        {
                            incorrectInput("Input valid " + info + "(Only accept positive numbers):");
                        }
                        else if (!isDecimalAllowed && input.ToString().Contains("."))
                        {
                            incorrectInput("Input valid " + info + ":");
                        }

                        else
                        {
                            isNumeric = true;
                        }
                    }

                    else
                    {
                        incorrectInput("Input valid " + info + ":");
                    }
                }


            }

            return input;

        }
        public static string inputId(string info, int numberOfChar)
        {
            int input = 0;

            bool isNumeric = false;
            while (!isNumeric)
            {
                var strNumber = inputLengthMax(numberOfChar);
                if (!(strNumber == String.Empty))
                {
                    bool inputFormat = int.TryParse(strNumber, out input);
                    if (inputFormat)
                    {
                        isNumeric = true;
                    }
                    else
                    {
                        incorrectInput("Input valid " + info + "(Press Enter to go back to Main Menu): ");
                    }
                }
                else
                {
                    return strNumber;
                }


            }
            return input.ToString();
        }
    }
}

