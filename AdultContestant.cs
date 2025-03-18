public class AdultContestant : Contestant
{
    public AdultContestant(string name, int age, char talentCode)
        : base(name, age, talentCode)
    {
        EntryFee = 30;
    }

    public override string ToString()
    {
        return base.ToString() + " (Adult)";
    }
}
