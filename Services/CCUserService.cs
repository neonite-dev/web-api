using workspace.Models;

namespace workspace.Services;

public static class CCUserService
{
    static List<CCUserModel> TEMP_TEST_CCUserList { get; }

    static int nextId = 1; // 첫번째 사용자 Id를 0으로 할게 아니면 1로 하자

    static CCUserService()
    {
        TEMP_TEST_CCUserList = new List<CCUserModel>
        { };
    }

    public static List<CCUserModel> GetAll() => TEMP_TEST_CCUserList;

    // FirstOrDefault = 조건을 만족하는 첫번째 요소를 반환하거나, 만족 요소가 없으면 기본값을 반환. -> 특정 조건을 만족하는 요소를 검색 및 필터링 등에 자주 쓰임
    public static CCUserModel? Get(int Id) => TEMP_TEST_CCUserList.FirstOrDefault(p => p.Id == Id);

    public static void Add(CCUserModel CCUser)
    {
        CCUser.Id = nextId++;
        CCUser.CreateAt = DateTime.Now;
        CCUser.ModifyAt = DateTime.Now;
        TEMP_TEST_CCUserList.Add(CCUser);
    }

    public static void Update(CCUserModel CCUser)
    {
        var index = TEMP_TEST_CCUserList.FindIndex(p => p.Id == CCUser.Id);
        if (index == -1)
            return;

        CCUser.CreateAt = TEMP_TEST_CCUserList[index].CreateAt;
        CCUser.ModifyAt = DateTime.Now;
        TEMP_TEST_CCUserList[index] = CCUser;
    }

    public static void Delete(int Id)
    {
        var CCUser = Get(Id);
        if (CCUser is null)
            return;
        TEMP_TEST_CCUserList.Remove(CCUser);
    }
}