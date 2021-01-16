using Microsoft.EntityFrameworkCore;

namespace asp_net_core_mvc_sample.Models {
  // DbContext クラスを継承
  public class Context : DbContext {
    // コンストラクタ
    public Context(DbContextOptions<Context> options): base(options) {

    }

    // モデルクラスへのアクセサー
    public DbSet<Book> Book {get; set;}
  }
}