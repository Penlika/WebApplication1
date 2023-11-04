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

        [Required(ErrorMessage ="Họ và tên không được để trống")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Tài khoản không đượng để trống")]
        [StringLength(50)]
        public string Taikhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(250, ErrorMessage ="Mật khẩu phải từ 8 đến 40 ký tự",MinimumLength =8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",
     ErrorMessage = "Mật khẩu tối thiểu tám ký tự, ít nhất một chữ hoa, một chữ thường, một số và một ký tự đặc biệt")]
        public string Matkhau { get; set; }

        [NotMapped]
        [Compare("Matkhau", ErrorMessage = "Mật khẩu nhập lại không được để trống")]
        public string MatKhauNL { get; set;}

        [Required(ErrorMessage = "Email không được để trống")]
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
