namespace Lab
{
    public interface ISavingApp
    {
        string FileCompany { get; set; }
        string FileTimeboard { get; set; }
        void SaveComp(MyCompany comp);

        void SaveTimeboard(Timeboard tb);

        MyCompany ReadComp();

        Timeboard ReadTimeboard();
    }
}
