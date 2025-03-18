using System;

public class Contestant
{
    public static char[] TalentCodes = { 'S', 'D', 'M', 'O' };
    public static string[] TalentDescriptions = { "Singing", "Dancing", "Musical Instrument", "Other" };

    public string Name { get; set; }
    public int Age { get; set; }
    private char talentCode;
    public string TalentDescription { get; private set; }
    public double EntryFee { get; protected set; }

    public char TalentCode
    {
        get { return talentCode; }
        set { SetTalentCode(value); }
    }

    public Contestant(string name, int age, char talentCode)
    {
        Name = name;
        Age = age;
        SetTalentCode(talentCode);
    }

    public void SetTalentCode(char code)
    {
        int index = Array.IndexOf(TalentCodes, code);
        if (index >= 0)
        {
            talentCode = code;
            TalentDescription = TalentDescriptions[index];
        }
        else
        {
            talentCode = 'I';
            TalentDescription = "Invalid Talent Code";
        }
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Talent: {TalentDescription}, Fee: ${EntryFee}";
    }
}
