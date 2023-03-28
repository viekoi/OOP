using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;


/*interface CheckBirth
{
    public int CheckBirth();
    public bool RealCheckBirth();
}*/

abstract class Staff
{
    protected string ID { get; set; }
    protected string FullName { get; set; }
    protected DateTime Dob { get; set; }
    protected string Phone { get; set; }
    protected string Email { get; set; }
    public virtual int employee_type { get; }
    protected string CertificateID { get; set; }
    protected string CertificateName { get; set; }
    protected string CertificateRank { get; set; }
    protected DateTime CertificateDate { get; set; }

    public Staff(string ID, string FullName, DateTime Dob, string Phone, string Email)
    {
        this.ID = ID;
        this.FullName = FullName;
        this.Dob = Dob;
        this.Phone = Phone;
        this.Email = Email;
    }
    public void ShowInfo()
    {
        Console.WriteLine("{0} {1} {2} {3} {4} {5} ", ID, FullName, Dob, Phone, Email, employee_type);
    }
    public virtual void GetCertificate(string CertificateID, string CertificateName, string CertificateRank, DateTime CertificateDate)
    {
        this.CertificateID = CertificateID;
        this.CertificateName = CertificateName;
        this.CertificateRank = CertificateRank;
        this.CertificateDate = CertificateDate;
    }
    public virtual void Certtificate()
    {
        Console.WriteLine("{0} {1} {2} {3}", CertificateID, CertificateName, CertificateRank, CertificateDate);
    }
    public string GetID()
    {
        return this.ID;
    }

}

class Fresher : Staff
{
    protected DateTime Graduation_date;
    protected string Graduation_rank;
    protected string Education;
    public override int employee_type => 1;
    public Fresher(string ID, string FullName, DateTime Dob, string Phone, string Email) : base(ID, FullName, Dob, Phone, Email)
    {
    }
    public void Get(DateTime Graduation_date, string Graduation_rank, string Education)
    {
        this.Graduation_date = Graduation_date;
        this.Graduation_rank = Graduation_rank;
        this.Education = Education;
    }
    public void ShowMe()
    {
        Console.WriteLine("{0} {1} {2} ", Graduation_date, Graduation_rank, Education);
    }
    /*public override void Certtificate()
    {
        base.Certtificate();
    }
    public override void GetCertificate(string CertificateID, string CertificateName, string CertificateRank, DateTime CertificateDate)
    {
        base.GetCertificate(CertificateID, CertificateName, CertificateRank, CertificateDate);
    }*/

}

class Intern : Staff
{
    protected string Major;
    protected int Semester;
    protected string University_name;
    public override int employee_type => 2;
    public Intern(string ID, string FullName, DateTime Dob, string Phone, string Email) : base(ID, FullName, Dob, Phone, Email)
    {
    }
    public void Get(string Major, int Sem, string Uni)
    {
        this.Major = Major;
        this.Semester = Sem;
        this.University_name = Uni;
    }
    public void ShowMe()
    {
        Console.WriteLine("{0} {1} {2}", Major, Semester, University_name);
    }
    /*public override void Certtificate()
    {
        base.Certtificate();
    }
    public override void GetCertificate(string CertificateID, string CertificateName, string CertificateRank, DateTime CertificateDate)
    {
        base.GetCertificate(CertificateID, CertificateName, CertificateRank, CertificateDate);
    }*/
}


class Experience : Staff
{
    protected int YearSkill;
    protected string ProSkill;
    public override int employee_type => 0;
    public Experience(string ID, string FullName, DateTime Dob, string Phone, string Email) : base(ID, FullName, Dob, Phone, Email)
    {

    }
    public void Get(int YearSkill, string ProSkill)
    {
        this.YearSkill = YearSkill;
        this.ProSkill = ProSkill;
    }
    public void ShowMe()
    {
        Console.WriteLine("Number of YearSkill and ProSkill: ");
        Console.WriteLine("{0} {1}", YearSkill, ProSkill);
    }
    /*public override void GetCertificate(string CertificateID, string CertificateName, string CertificateRank, DateTime CertificateDate)
    {
        base.GetCertificate(CertificateID, CertificateName, CertificateRank, CertificateDate);
    }
    public override void Certtificate()
    {
        base.Certtificate();
    }*/


}




class Program
{
    public static string CheckStringInput()
    {
        string a;
        while (true)
        {
            a = Console.ReadLine();

            if (a == "")
            {
                Console.WriteLine("error");
                continue;
            }
            else
            {
                return a;
            }
        }

    }
    public static DateTime CheckDateTimeInput()
    {
        DateTime Dob;
        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Năm: ");
                int Year = int.Parse(Console.ReadLine());
                Console.Write("Tháng: ");
                int Month = int.Parse(Console.ReadLine());
                Console.Write("Ngày: ");
                int Day = int.Parse(Console.ReadLine());
                Dob = new DateTime(Year, Month, Day);
                break;
            }
            catch
            {
                Console.WriteLine("error");
                continue;
            }
        }
        return Dob;
    }
    public static int CheckIntInput()
    {
        int a;
        while (true)
        {
            try
            {
                a = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("error");
                continue;
            }
        }
        return a;

    }

    public static string CheckEmailInput()
    {

        while (true)
        {
            string Email = CheckStringInput();
            var trimmedEmail = Email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                continue; // suggested by @TK-421
            }
            else
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(Email);
                    return addr.Address;
                }
                catch
                {
                    Console.WriteLine("error");
                    continue;
                }
            }

        }

    



    }
    public static Staff AddFesher() {
        Console.Write("Nhập ID: ");
        string ID = CheckStringInput();
        Console.Write("Họ Và Tên: ");
        string FullName = CheckStringInput();
        Console.Write("Ngày tháng năm sinh: ");
        DateTime Dob = CheckDateTimeInput();
        Console.Write("Số điện thoại: ");
        string Phone = CheckStringInput();
        Console.Write("Email: ");
        string Email = CheckEmailInput();
        Console.WriteLine("{0} {1} {2} {3} {4}", ID, FullName, Dob, Phone, Email);
        Fresher NewFresher = new Fresher(ID, FullName, Dob, Phone, Email);
        Console.Write("ID Bằng cấp: ");
        string CertificateID = CheckStringInput();
        Console.Write("Tên Bằng cấp: ");
        string CertificateName = CheckStringInput();
        Console.Write("Bằng cấp loại: ");
        string Rank = CheckStringInput();
        Console.Write("Ngày cấp bằng: ");
        DateTime CertificateDate = CheckDateTimeInput();
        NewFresher.GetCertificate(CertificateID, CertificateName, Rank, CertificateDate);
        NewFresher.ShowInfo();
        NewFresher.Certtificate();
        Console.Write("Ngày tốt nghiệp: ");
        DateTime GraduationDate = CheckDateTimeInput();
        Console.Write("Tốt nghiệp loại: ");
        string GraduationRank = CheckStringInput();
        Console.Write("Trường tốt nghiệp loại: ");
        string Education = CheckStringInput();
        NewFresher.Get(GraduationDate, GraduationRank, Education);
        NewFresher.ShowMe();
        return NewFresher;
        
    }


    public static Staff AddIntern()
    {
        Console.Write("Nhập ID: ");
        string ID = CheckStringInput();
        Console.Write("Họ Và Tên: ");
        string FullName = CheckStringInput();
        Console.Write("Ngày tháng năm sinh: ");
        DateTime Dob = CheckDateTimeInput();
        Console.Write("Số điện thoại: ");
        string Phone = CheckStringInput();
        Console.Write("Email: ");
        string Email = CheckEmailInput();
        Console.WriteLine("{0} {1} {2} {3} {4}", ID, FullName, Dob, Phone, Email);
        Intern NewIntern = new Intern(ID, FullName, Dob, Phone, Email);
        Console.Write("ID Bằng cấp: ");
        string CertificateID = CheckStringInput();
        Console.Write("Tên Bằng cấp: ");
        string CertificateName = CheckStringInput();
        Console.Write("Bằng cấp loại: ");
        string Rank = CheckStringInput();
        Console.Write("Ngày cấp bằng: ");
        DateTime CertificateDate = CheckDateTimeInput();
        NewIntern.GetCertificate(CertificateID, CertificateName, Rank, CertificateDate);
        NewIntern.ShowInfo();
        NewIntern.Certtificate();
        Console.Write("Trường Đại học đã học: ");
        string UniversityName = CheckStringInput();
        Console.Write("Chuyên ngành: ");
        string Major = CheckStringInput();
        Console.Write("Niên Khóa: ");
        int Semester = CheckIntInput();
        NewIntern.Get(Major, Semester, UniversityName);
        NewIntern.ShowMe();
        return NewIntern;
    }

    public static Staff AddExperience()
    {
        Console.Write("Nhập ID: ");
        string ID = CheckStringInput();
        Console.Write("Họ Và Tên: ");
        string FullName = CheckStringInput();
        Console.Write("Ngày tháng năm sinh: ");
        DateTime Dob = CheckDateTimeInput();
        Console.Write("Số điện thoại: ");
        string Phone = CheckStringInput();
        Console.Write("Email: ");
        string Email = CheckEmailInput();
        Console.WriteLine("{0} {1} {2} {3} {4}", ID, FullName, Dob, Phone, Email);
        Experience NewExperience = new Experience(ID, FullName, Dob, Phone, Email);
        Console.Write("ID Bằng cấp: ");
        string CertificateID = CheckStringInput();
        Console.Write("Tên Bằng cấp: ");
        string CertificateName = CheckStringInput();
        Console.Write("Bằng cấp loại: ");
        string Rank = CheckStringInput();
        Console.Write("Ngày cấp bằng: ");
        DateTime CertificateDate = CheckDateTimeInput();
        NewExperience.GetCertificate(CertificateID, CertificateName, Rank, CertificateDate);
        NewExperience.ShowInfo();
        NewExperience.Certtificate();
        Console.Write("Số năm kinh nghiệm: ");
        int YearSkill = CheckIntInput();
        Console.Write("Kỹ năng: ");
        string ProSkill = CheckStringInput();
        NewExperience.Get(YearSkill,ProSkill);
        NewExperience.ShowMe();
        return NewExperience;
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<Staff> Freshers = new List<Staff>();
        List<Staff> Interns = new List<Staff>();
        List<Staff> Experiences = new List<Staff>();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Chọn 1 phương án:");
            Console.WriteLine("Chọn 0 để thêm 1 nhân viên Experience");
            Console.WriteLine("Chọn 1 để thêm 1 nhân viên Fresher");
            Console.WriteLine("Chọn 2 để thêm 1 nhân viên Interns");
            Console.WriteLine("Chọn 3 để tìm 1 nhân viên");
            Console.WriteLine("Chọn 4 để xóa 1 nhân viên");
            Console.WriteLine("Chon 5 để exit");

            int Option = int.Parse(Console.ReadLine());
            switch (Option)
            {
                case 1:
                    Freshers.Add(AddFesher());
                    break;
                case 2:
                    Interns.Add(AddIntern());
                    break;
                case 0:
                    Experiences.Add(AddExperience());
                    break;
                case 3:
                    Console.WriteLine("Chọn 0 để tìm 1 nhân viên Experience theo ID");
                    Console.WriteLine("Chọn 1 để tìm 1 nhân viên Fresher theo ID");
                    Console.WriteLine("Chọn 2 để tìm 1 nhân viênn Interns theo ID");
                    int FindOption = int.Parse(Console.ReadLine());
                    if (FindOption == 1)
                    {
                        if (Freshers.Count() == 0) {
                            Console.WriteLine("Mảng rỗng");
                            break;
                        }
                        Console.WriteLine("Nhập ID");
                        string LOOK = CheckStringInput();
                        for (int i = 0; i < Freshers.Count(); i++) {
                            Console.WriteLine(LOOK == Freshers[i].GetID());
                            if (LOOK == Freshers[i].GetID())
                            {
                                Freshers.Remove(Freshers[i]);
                                break;
                            }
                        }

                        
                    }
                    else if (FindOption == 2)
                    {
                        if (Interns.Count() == 0)
                        {
                            Console.WriteLine("Mảng rỗng");
                            break;
                        }
                        Console.WriteLine("Nhập ID");

                        string LOOK = CheckStringInput();
                        for (int i = 0; i < Interns.Count(); i++)
                        {
                            
                            if (LOOK == Interns[i].GetID())
                            {
                                Interns.Remove(Interns[i]);
                                break;
                            }
                        }
                    }
                    else if (FindOption == 0)
                    {
                        if (Experiences.Count() == 0)
                        {
                            Console.WriteLine("Mảng rỗng");
                            break;
                        }
                        Console.WriteLine("Nhập ID");

                        string LOOK = CheckStringInput();
                        for (int i = 0; i <Experiences.Count(); i++)
                        {

                            if (LOOK == Experiences[i].GetID())
                            {
                                Experiences.Remove(Experiences[i]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid");
                    }
                    break;
                case 4:
                    Console.WriteLine("Chọn 0 để xóa 1 nhân viên Experience theo ID");
                    Console.WriteLine("Chọn 1 để xóa 1 nhân viên Fresher theo ID");
                    Console.WriteLine("Chọn 2 để xóa 1 nhân viênn Interns theo ID");
                   
                    
                    int DelOption = int.Parse(Console.ReadLine());
                    if (DelOption == 1)
                    {
                        if (Freshers.Count() == 0)
                        {
                            Console.WriteLine("Mảng rỗng");
                            break;
                        }
                        Console.WriteLine("Nhập ID");

                        string LOOK = CheckStringInput();
                        for (int i = 0; i < Freshers.Count(); i++)
                        {
                            Console.WriteLine(LOOK == Freshers[i].GetID());
                            if (LOOK == Freshers[i].GetID())
                            {
                                Console.WriteLine("true");
                                Freshers[i].ShowInfo();
                                ((Fresher)Freshers[i]).ShowMe();
                                Freshers[i].Certtificate();
                                break;
                            }
                        }


                    }
                    else if (DelOption == 2)
                    {
                        if (Interns.Count() == 0)
                        {
                            Console.WriteLine("Mảng rỗng");
                            break;
                        }
                        Console.WriteLine("Nhập ID");

                        string LOOK = CheckStringInput();
                        for (int i = 0; i < Interns.Count(); i++)
                        {

                            if (LOOK == Interns[i].GetID())
                            {
                                Console.WriteLine("true");
                                Interns[i].ShowInfo();
                                ((Intern)Interns[i]).ShowMe();
                                Interns[i].Certtificate();
                                break;
                            }
                        }
                    }
                    else if (DelOption == 0)
                    {
                        if (Experiences.Count() == 0)
                        {
                            Console.WriteLine("Mảng rỗng");
                            break;
                        }
                        Console.WriteLine("Nhập ID");

                        string LOOK = CheckStringInput();
                        for (int i = 0; i < Experiences.Count(); i++)
                        {

                            if (LOOK == Experiences[i].GetID())
                            {
                                Console.WriteLine("true");
                                Experiences[i].ShowInfo();
                                ((Experience)Experiences[i]).ShowMe();
                                Experiences[i].Certtificate();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid");
                    }
                    break;
                case 5:
                    isRunning = false;
                    break;
            }
            

            
            
        }
        

        
    }
}