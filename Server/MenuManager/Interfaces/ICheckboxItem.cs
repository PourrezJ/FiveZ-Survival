namespace FiveZ
{
    interface ICheckboxItem
    {
        bool Checked { get; set; }

        bool IsInput();
    }
}