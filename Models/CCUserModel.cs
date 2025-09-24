using System.ComponentModel.DataAnnotations;

namespace workspace.Models;

public class CCUserModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool MarketingAgree { get; set; }

    [EmailAddress(ErrorMessage = "유효하지 않은 이메일 주소입니다.")]
    public string? Email { get; set; }

    public string? Favorite { get; set; }

    public DateTime? Birth { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime ModifyAt { get; set; }

    public CCUserModel()
    {
        CreateAt = DateTime.Now;
        ModifyAt = DateTime.Now;
    }
    // 등록 일시와 수정 일시는 그냥 null 허용을 할 경우 생각지 못한 문제를 야기할 수 있고,
    // not null처리를 해도 min.value가 되어서 나중에 SQL로 셀렉 시 (예를 들면 특정일 이전에 등록한 사람들 조회에 추가되버림) 애매한 상황이 생길 수 있다.
    // 차라리 생성자로 초기화를 해주는 작업이 차후를 생각하면 덜 귀찮은 방법일 것이다.
}