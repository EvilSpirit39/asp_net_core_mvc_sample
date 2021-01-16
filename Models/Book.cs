using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace asp_net_core_mvc_sample.Models {

  public class Book : IValidatableObject {

    // ID
    public int Id {get; set;}
    
    // 書名
    [DisplayName("書名")]
    [StringLength(100)]
    public string Title {get; set;}

    [DisplayName("カテゴリ")]
    [StringLength(100)]
    // カテゴリ
    public string Category {get; set;}

    [DisplayName("著者")]
    [StringLength(100)]
    // 著者
    public string Author { get; set;}

    // 出版社
    [DisplayName("出版社")]
    [StringLength(100)]
    public string Publisher {get; set;}

    // 価格
    [DisplayName("価格")]
    [Range(0, 1000000)]
    [DataType(DataType.Currency)]
    public int Price {get; set;}

    // タイムスタンプ
    [Timestamp]
    public byte[] RowVersion {get; set;}

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
      if (Title == "" && Author == "" && Publisher == "") {
        yield return new ValidationResult("書名、著者、出版社のいずれかは入力が必要");
      }
    }
  }
}