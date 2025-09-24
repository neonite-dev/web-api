namespace workspace.Models;

public class CCBoardModel
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? TextContent { get; set; } // Content로 하니 MS-SQL 열이름에서 자꾸 대괄호를 친다. <model>.CONTENT라는 쿼리문이 있기 때문으로 보인다. => 콘텐츠 쿼리(데이터 마이닝)

    public string? Author { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime ModifyAt { get; set; } // 의외로 게시글이나 댓글도 수정사항이나 수정시간에 민감한 요구가 많다.

    public CCBoardModel()
    {
        CreateAt = DateTime.Now;
        ModifyAt = DateTime.Now;
    }
}