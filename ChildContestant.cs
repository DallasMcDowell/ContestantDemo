public class ChildContestant : Contestant
{
    public ChildContestant(string name, int age, char talentCode)
        : base(name, age, talentCode)
    {
        EntryFee = 15;
    }

    public override string ToString()
    {
        return base.ToString() + " (Child)";
    }
}
