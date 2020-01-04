using System;
using System.Data.SqlClient;

class DBDemo1
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader dr;

    public DBDemo1()
    {
        conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\practicec#\ConsoleApp3\ConsoleApp3\Database1.mdf;Integrated Security=True");
    }

    public void SaveStudent()
    {
        Console.WriteLine("enter rollno,name,marks");
        int rno = int.Parse(Console.ReadLine());
        string sname = Console.ReadLine();
        int marks = int.Parse(Console.ReadLine());
        cmd = new SqlCommand("Insert Into Student(RNo,SName,Marks) values(" + rno + ",'" + sname + "'," + marks + ")", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("data saved");
    }
    public void SearchStudent()
    {
        Console.WriteLine("enter rollno to search");
        int rno = int.Parse(Console.ReadLine());
        cmd = new SqlCommand("Select * From Student Where Rno=" + rno + " ", conn);
        conn.Open();
        dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            string sname = dr["SName"].ToString();
            int marks = int.Parse(dr["Marks"].ToString());
            Console.WriteLine("RollNo=" + rno);
            Console.WriteLine("name=" + sname);
            Console.WriteLine("marks=" + marks);
        }
        else
        {
            Console.WriteLine("data not found");
        }
        conn.Close();
    }

    public void UpdateStudent()
    {
        Console.WriteLine("enter roll num to update");
        int rno = int.Parse(Console.ReadLine());
        Console.WriteLine("enter the value of new name");
        string sname = Console.ReadLine();
        Console.WriteLine("enter new marks");
        int marks = int.Parse(Console.ReadLine());
        cmd = new SqlCommand("Update Student Set SName='"+ sname +"',Marks= "+ marks+" where RNo=" + rno + "", conn);
        conn.Open();
        int k = cmd.ExecuteNonQuery();
        if (k==1)
        {
            Console.WriteLine("database updated");
        }
        else
        {
            Console.WriteLine("updation fail");
        }
        conn.Close();
    }
    public void DeleteStudent()
    {
        Console.WriteLine("enter rollnum to be delete");
        int rno = int.Parse(Console.ReadLine());
        cmd = new SqlCommand("Delete From Student Where RNo=" + rno + "", conn);
        conn.Open();
        int k = cmd.ExecuteNonQuery();
        if(k==1)
        {
            Console.WriteLine("data delete successful");
        }
        else
        {
            Console.WriteLine("data delete unsuccessful");
        }
        conn.Close();
    }
    public void ShowAllStudent()
    {
        cmd = new SqlCommand("Select * From Student", conn);

        conn.Open();
        dr = cmd.ExecuteReader();
        while(dr.Read())
        {
            int rno = int.Parse(dr["RNo"].ToString());
            string sname = dr["SName"].ToString();
            int marks = int.Parse(dr["Marks"].ToString());
            Console.WriteLine(rno + " " + sname + " " + marks);
        }
        conn.Close();
    }
    public static void Main()
    {
        int ch;
        DBDemo1 obj1 = new DBDemo1();
        do
        {
            Console.WriteLine("enter choice \n1.save\n2.search\n3.update\n4.delete\n5.showall\n6.quit");
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    obj1.SaveStudent();
                    break;
                case 2:
                    obj1.SearchStudent();
                    break;
                case 3:
                    obj1.UpdateStudent();
                    break;
                case 4:
                    obj1.DeleteStudent();
                    break;
                case 5:
                    obj1.ShowAllStudent();
                    break;
                case 6:
                    Console.WriteLine("this prog is over");
                    break;
                default:
                    Console.WriteLine("invalid character");
                    break;
            }
        }
        while (ch != 6);
    }
}



