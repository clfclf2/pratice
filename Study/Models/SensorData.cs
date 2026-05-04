using System.ComponentModel.DataAnnotations;

namespace Study.Models;

public class SensorData
{
    [Key]
    public int Id { get; set; }           // 데이터마다 붙는 번호 (자동 생성)
    public string DeviceId { get; set; } = string.Empty; // 기기 이름
    public double Value { get; set; }     // 센서 측정 값
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // 저장된 시간
}