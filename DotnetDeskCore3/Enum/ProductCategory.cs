using System.ComponentModel.DataAnnotations;

namespace DotnetDeskCore3.Enum
{
    public enum ProductCategory
    {
        Other = 0,
        Monitor = 1,
        Phone = 2,
        Desktop = 3,
        Laptop = 4,
        Printer = 5,
        [Display(Name = "Other Hardware")]
        OtherHardware = 6,
        Windows = 7,
        Word = 8,
        Excel = 9,
        Powerpoint = 10,
        [Display(Name = "Other Software")]
        OtherSoftware = 11
    }
}
