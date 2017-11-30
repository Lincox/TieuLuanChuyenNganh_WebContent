namespace LoginTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel.DataAnnotations;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            BaiViets = new HashSet<BaiViet>();
            BinhLuans = new HashSet<BinhLuan>();
            LichSuNapTiens = new HashSet<LichSuNapTien>();
            TheLoais = new HashSet<TheLoai>();
        }

        [Key]
        [Column("idUser")]
        [StringLength(50)]
        [Display(Name ="ID User")]
        public string idUser { get; set; }

        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Giới tính")]
        public bool? GioiTinh { get; set; }

        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Ngày đăng ký")]
        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Display(Name = "User Name")]
        [StringLength(50)]
        public string Usename { get; set; }

        [Display(Name = "Password")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Quyền")]
        [StringLength(50)]
        public string Quyen { get; set; }

        [Display(Name = "Quyền Viết Bài")]
        public bool? QuyenVietBai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuNapTien> LichSuNapTiens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheLoai> TheLoais { get; set; }
    }
}
