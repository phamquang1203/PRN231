using _26_BuiVanToan_BusinessObject ;

namespace _26_BuiVanToan_DataAccess.Repositories.impl
{
    public class MemberRepository : IMemberRepository
    {
        void IMemberRepository.DeleteMember(Member member) => MemberDAO.DeleteMember(member);
    

        Member IMemberRepository.GetMemberByEmail(string email) =>MemberDAO.FindMemberByEmail(email);
     

        Member IMemberRepository.GetMemberById(int id)=>MemberDAO.FindMemberById(id);

        List<Member> IMemberRepository.GetMembers() =>MemberDAO.GetMembers();
   

        List<Order> IMemberRepository.GetOrders(int MemberId)=>OrdersDAO.FindAllOrdersByMemberId(MemberId);
   

        void IMemberRepository.SaveMember(Member member)=> MemberDAO.SaveMember(member);
     

        List<Member> IMemberRepository.Search(string keyword) => MemberDAO.Search(keyword);


        void IMemberRepository.UpdateMember(Member member) => MemberDAO.UpdateMember(member);
      
    }
}
