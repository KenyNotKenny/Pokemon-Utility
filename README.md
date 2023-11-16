# Pokemon-Utility
This is dev branch

Hướng dẫn query database:

Có thể gọi lên Class MainContext từ bất cứ đâu, nó là 1 Singleton với instance được private.

Mọi tương tác với database thông qua Singleton này mọi người đừng tạo đối tượng của Class PokemonContext. Mục đích tui tạo cái này để giữ 1 context sử dụng xuyên suốt chương trình.

Class MainContext có 2 member public có thể gọi :
  MainContext.Connected 
    - bool property - Để kiểm tra kết nối với database. Kết nối database có thể bị ngắt nếu không có kết nối Internet hoặc đường truyền quá chậm. Nếu là trường hợp khác thì báo cho tui để tui kiểm tra database

  MainContext.Query( Action onReceive, Action<MainContext> onFailure)  
    - void method - Là cách duy nhất nên query dữ liệu từ database. 
    Hàm Query thực hiện sẵn việc check kết nối database nên không cân gọi MainContext.Connected trước mỗi khi query. MainContext.Connected chỉ dùng khi muốn check database mà không query
 
 Sử dụng như sau:


MainContext.Query(
    onReceive: context => { /* Your code go here */ },    //  "context" là parameter nên đặt là gì cũng được không cần phải là "context"
    onFailure: () => { /* Your code go here */ }          // sẽ chạy nếu không có kết nối với database , onReceive sẽ không được chay trong trường hợp này .
);

Trong đoạn code của onReceive:

"context" sẽ mang giá trị của một instance của DbContext Class nên mọi người có thể sử dụng nó để query
chi tiết về query như thế nào thì được chỉ rõ ở https://www.entityframeworktutorial.net/entityframework6/querying-with-entityframework.aspx

Ví dụ của sử dụng Query:

MainContext.Query(
    onReceive: context =>
    {
        textBlock.Text = context.Pokemons.Where(s => s.Id <= 6).ToList()[4].Name;
    },
    onFailure: () => textBlock.Text = "No Connection"
);

Hàm trên khi chạy sẽ dùng Table Pokemon, select những dòng có id <= 6, sau đó lấy dòng kết quả số 4 của sau khi select, lấy cột name của dòng đấy ra sau đó set chữ cho textBlock bằng giá trị đó

Kết quả : charmeleon

Trong trường hợp không có kết nối

Kết quả : No Connection

*Gợi ý: nếu để lấy hàng theo primary key của table theo Primary Key thì dùng hàm Find() sẽ tốt hơn
Hiện chỉ có table Pokemon và Move có Primery Key đơn là id
