using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWithEF.Enums
{
    public enum LanguagesEnum
    {
        [Display(Name ="English Language")]
        English=10,
        [Display(Name = "Sindhi Language")]
        Sindhi =11,
        [Display(Name = "Siraiki Language")]
        Siraiki =12,
        [Display(Name = "Urdu Language")]
        Urdu =13,
        [Display(Name = "Punjabi Language")]
        Punjabi =14,
        [Display(Name = "Balouchi Language")]
        Balouchi =15,
        [Display(Name = "Pashto Language")]
        Pashto =16,
        [Display(Name = "Kashmiri Language")]
        Kashmiri =17
    }
}
