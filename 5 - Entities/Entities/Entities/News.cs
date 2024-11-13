using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Notifications;

namespace Entities.Entities;

[Table("TB_NEWS")]
public class News : Notify
{
    [Key]
    [Column("NEWS_ID")]
    public int NewsId { get; set; }

    [Column("NEWS_TITLE")]
    [StringLength(255)]
    public string NewsTitle { get; set; }

    [Column("NEWS_INFORMATION")]
    [StringLength(150)]
    public string NewsInformation { get; set; }

    [Column("NEWS_ACTIVE")]
    public bool NewsActive { get; set; }

    [Column("NEWS_DATETIME_INSERT")]
    public DateTime NewsDatetimeInsert { get; set; }

    [Column("NEWS_TIME_LAST_CHANGED")]
    public DateTime NewsTimeLastChanged { get; set; }
    
    [ForeignKey("ApplicationUser")]
    [Column(Order = 1)]
    public string UserId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    
}
