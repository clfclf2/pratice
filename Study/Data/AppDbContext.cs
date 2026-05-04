using Microsoft.EntityFrameworkCore;
using Study.Models; // 아까 만든 Models 폴더의 설계도를 가져옵니다.

namespace Study.Data;

// DbContext는 '데이터베이스 문맥'이라는 뜻으로, DB와 대화하는 주체입니다.
public class AppDbContext : DbContext
{
    // 이 생성자는 서버가 켜질 때 DB 연결 정보를 이 파일로 전달해주는 역할을 합니다.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSet은 "이 모델을 가지고 DB에 테이블(표)을 만들어줘!"라는 뜻입니다.
    // 이제 DB 안에 'Sensors'라는 이름의 표가 생길 거예요.
    public DbSet<SensorData> Sensors { get; set; }
}