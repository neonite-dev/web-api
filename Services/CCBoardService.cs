using workspace.Models;

namespace workspace.Services;

public static class CCBoardService
{
    static List<CCBoardModel> TEMP_TEST_CCBoardList { get; }

    static int nextId = 1;

    static CCBoardService()
    {
        TEMP_TEST_CCBoardList = new List<CCBoardModel>
        { };
    }

    public static List<CCBoardModel> GetAll() => TEMP_TEST_CCBoardList;

    public static CCBoardModel? Get(int Id) => TEMP_TEST_CCBoardList.FirstOrDefault(p => p.Id == Id);

    public static void Add(CCBoardModel CCBoard)
    {
        CCBoard.Id = nextId++;
        CCBoard.CreateAt = DateTime.Now;
        CCBoard.ModifyAt = DateTime.Now;
        TEMP_TEST_CCBoardList.Add(CCBoard);
    }

    public static void Update(CCBoardModel CCBoard)
    {
        var index = TEMP_TEST_CCBoardList.FindIndex(p => p.Id == CCBoard.Id);
        if (index == -1)
            return;

        CCBoard.CreateAt = TEMP_TEST_CCBoardList[index].CreateAt;
        CCBoard.ModifyAt = DateTime.Now;
        TEMP_TEST_CCBoardList[index] = CCBoard;
    }

    public static void Delete(int Id)
    {
        var CCBoard = Get(Id);
        if (CCBoard is null)
            return;
        TEMP_TEST_CCBoardList.Remove(CCBoard);
    }
}