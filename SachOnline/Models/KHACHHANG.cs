namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDATHANGs = new HashSet<DONDATHANG>();
        }

        [Key]
        public int MaKH { get; set; }

        [Required(ErrorMessage ="Ho ten ko dc de trong")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Tai Khoan ko dc de trong")]
        [StringLength(50)]
        public string Taikhoan { get; set; }

        [Required(ErrorMessage = "mat khau ko dc de trong")]
        [StringLength(250, ErrorMessage ="mat khau ko phai tu 8 den 40 ky tu",MinimumLength =8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",
     ErrorMessage = "Mật khẩu tối thiểu tám ký tự, ít nhất một chữ hoa, một chữ thường, một số và một ký tự đặc biệt")]
        public string Matkhau { get; set; }

        [NotMapped]
        [Compare("Matkhau", ErrorMessage = "mat khau nhap lai ko dc de trong")]
        public string MatKhauNL { get; set;}

        [Required(ErrorMessage = "Email ko dc de trong")]
        [StringLength(100)]
        public string Email { get; set; }


        [StringLength(200)]
        public string DiachiKH { get; set; }

        [StringLength(50)]
        public string DienthoaiKH { get; set; }

        public DateTime? Ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }
    }
}
