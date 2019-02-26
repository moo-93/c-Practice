# c# 연습

- 입사할 회사의 주요 언어가 c#, asp.net이므로 낙서느낌으로 기록할 예정
- java와 대체로 비슷하나 다른부분 또는 새로운 부분을 기록할 예정
- 순서가 조금 어긋나서 가독성이 떨어질 염려가 있으나 지속적인 수정을 할 것
- 위의 소스코드는 안봐도 무방하다.
--------------------
## C# 기초

- 닷넷의 기본 타입에 대한 c#의 별칭 <br>

    c# | 대응되는 닷넷 프레임워크 형식 
    ------------|-------------
    sbyte | System.Sbyte
    byte | System.Byte
    short | System.Int16
    ushort | System.UInt16
    int | System.Int32 
    uint | System.UInt32 
    long | System.Int64 
    ulong | System.UInt64
    flaot | System.Single
    double | System.Double
    decimal | System.Decimal
    char | System.Char
    string | System.String
    bool | System.Boolean
    * decimal은 double의 상위 단계라 생각 (double 8바이트 decimal 16바이트) 

- 상수 const ==> javascript의 const와 같다고 생각하면 된다.
### foreach(표현식요소의_자료형 변수명 in 표현식)
    ex) foreach(int elem in arr)
------------------------

## c# 객체지향 문법

### namespace(이름공간)
- 중복된 클래스를 나누기 위해 존재, 따라서 각각 다른 이름공간에 같은 클래스를 주입 할 수 있다.
- 다만 설정된 namespace를 한 곳에 적용시키려면 코드가 길어진다.

```
namespace Comunication{
    class Http{

    }
}
namespace Disk.FileSystem{
    class File{

    }
}
namespae ConsoleApp1{
    class Program{
        static void Main(string[] args){
            Comunication.Http http = new Comunication.Http(); // 너무길어..
            Disk.FileSystem.File file = new Disk.FileSystem.File(); // 너무길어..
        }
    }
}
```

- 이를 해결하기 위해 using 예약어 사용(c++에서도 사용 했었다.)
- 즉 using에 namespace를 등록하면 일일히 namespace를 적을 필요가 없다.

```
using Comunication;
using Disk.FileSystem;

namespace Comunication{
    class Http{

    }
}
namespace Disk.FileSystem{
    class File{

    }
}
namespae ConsoleApp1{
    class Program{
        static void Main(string[] args){
            Http http = new Http(); // good
            File file = new File(); // good
        }
    }
}

```

### 접근 제한자

- c#에서의 접근 제한자는 5가지로 정해져있다.
    - private, protected, public, internal, internal protected
    - internal : 동일한 어셈블리 내에서는 public에 준한 접근을 허용
    - internal protected : 동일 어셈블리 내에서 정의된 파생 클래스까지만 접근 허용
- 자바와 다르게 명시되지 않은 경우가 각각 다르다.
    - class 생략 경우 internal
    - class 내부 멤버에 대해서는 private


### 프로퍼티
- getter와 setter를 일일히 만드는게 불편해서 생긴거라고 한다. (개인적으로 제일 편하고 좋은 문법인듯)
```
class Circle
    {
        double pi = 3.14;

        // 프로퍼티 
        public double Pi // 접근제한자 타입 프로퍼티명
        {
            get { return pi; } // 접근제한자 get {return 해야할것;}
            set { pi = value; } // 접근제한자 set {...} value라는 예약어를 사용해야함!
        }
    }

    ... 생략 ...

    Circle o = new Circle();
    o.Pi = 3.14159; // 쓰기
    double piValue = o.Pi; // 읽기
```
### 상속
```
public class 자손클래스 : 부모클래스 {
    ...
}
```
- c#에서는 상속을 의도적으로 막을 수 있음 sealed라는 예약어를 이용
```
sealed class 클래스명{

}

public class 클래스명2: 클래스명 {
    // 컴파일 오류 발생!
}
```
- 또한 자바와 마찬가지로 c#도 다중 상속을 지원하지 않는다!

### 형변환
#### as, is연산자
- 명시적 형변환을 하는 경우 가능한지 불가능한지 확인하는 방법
```
Computer pc = new Computer();
Notebook notebook = pc as Notebook;

if(notebook != null){
    notebook.CloseLid();
}
```
- Computer class가 부모 클래스, Notebook class가 자식클래스
- 부모클래스가 자식클래스로 명시적으로 형 변환하려는 경우 컴파일오류가 아닌 프로그램 실행 시 오류 발생
- 따라서 위 as 연산자를 이용하면 형변환 시 값이 반환되고 불가능 시 null를 반환
- as 연산자는 참조형 변수와 참조형 타입으로의 체크만 가능!

```
int n = 5;
if((n as string) != null){
    console.WriteLine("변수 n은 string 타입");
} // 참조형 타입이 아니므로 컴파일 오류가 발생 한다. 따라서 as 자리에 is 연산자를 바꿔 사용하자
```
- 즉 is,as 의 사용 기준은 참조형타입이냐 아니냐를 따지면 된다.
- is 연산자는 boolean 타입으로 추정(정확하진 않음!)
- 정리하자면 as 연산자는 참조형 변수가 내가 원하는 참조형 타입으로 형 변환이 가능한가를 체크<br>
  is 연산자는 참조형 변수가 내가 원하는 참조형이 아닌 타입으로 형 변환이 가능한가를 체크

### System.Object

#### GetType
- 해당 클래스의 정보를 가져올 수 있음
```
Type type = o.GetType();

Console.WriteLine(type.FullName); // Type 클래스의 FullName 프로퍼티 호출
Console.WriteLine(type.IsClass); // 클래스가 맞는지 아닌지 확인
Console.WriteLine(type.IsArray); // 배열이 맞는지 아닌지 확인
Console.WriteLine(o.GetType().FullName); // 바로 사용 가능
```

- 위에 사용된 방법은 "클래스의 인스턴스"로 부터 Type을 구했다.
- 다음 방식은 "클래스의 이름"에서 곧바로 Type을 구하는 방법이다.

```
Type type2 = typeof(double);

Console.WriteLine(type2.FullName);
Console.WriteLine(typeof(Circle).FullName); // 역시 바로 사용가능하다.
```
- 이때 typeof(타입 또는 클래스명) 예약어를 사용한다.
- 두 방식은 순서만 다를뿐 같은 결과를 도출한다!

#### GetHashCode
- 자바와 다르게 c#은 Get을 붙인다 참고하자

### System.Array

#### Array

- Array 타입 멤버

멤버 | 타입 | 설명
----|----|----
Rank |인스턴스 프로퍼티 | 차원(dimension) 수 반환
Length|인스턴스 프로퍼티| 요소(element) 수 반환
Sort|정적 메서드| 정렬(기본은 오름차순)
GetValue|인스턴스 메서드| 지정된 인덱스의 배열 요소 값을 반환
Copy|정적 메서드| 해당 배열을 복사

```
bool[,] boolArray = new bool[,] {{true,true},{true,true}} // ,부분을 통해 2차원 배열 사용
```

#### this
```
class book{
    decimal isbn;

    public Book(decimal isbn){
        this.isbn = isbn;
    }
}
```
- 자바와 this 개념이 다르다 참고하자.

- 또한 this 예약어를 통해 생성자 내에서 다른 생성자를 호출할 수 있다.
```
class book {
    string title;
    decimal isbn13;
    string author;

    public Book(string title) : this(this,0){ //1

    }
    
    public Book(string title, decimal isbn13) : this(title, isbn13, string.Empty){ //2

    }

    public Book(string title, decimal isbn13, string author){ //3
        this.title = title;
        this.isbn13 = isbn13;
        this.author = author;
    }

    public Book() : this(string.Empty, 0, string.Empty){

    }
}
```
- 1번과 2번 생성자 선언문에 인스턴스필드를 초기화할 필요가 없다.
- 3번 생성자에서 인스턴스 필드를 전부 초기화하므로 3번 생성자를 불러와서 1,2번을 초기화 한다.
- 어떤 방식인지는 모르나 이런 로직의 this 예약어를 사용해야할 경우가 있다고 한다!
- this는 정적에 사용 불가능! (static) 너무 당연하고 ..

#### base
- java에선 super와 같은 뜻으로 사용되는걸 참고

### 메서드 오버라이드
- java와 똑같이 작성해도 오버라이드가 가능은 하다.
```
    class Mammal
    {
        public void Move()
        {
            Console.WriteLine("이동한다.");
        }
    }
    
    class Lion : Mammal
    {
        public void Move()
        {
            Console.WriteLine("네발로 이동한다.");
        }
    }
```
```
Lion lion = new Lion();
lion.Move();

Whale whale = new Whale();
whale.Move();
```
- 하지만 c#에서는 다음과 같이 암시적 형변환이 이루어진경우 문제가 발생한다.
```
Lion lion = new Lion();
Mammal one = lion; // 부모타입으로 형변환
one.Move();

// 출력결과
이동한다.
```
- 부모타입으로 형변환을 해버리니 부모클래스의 Move() 메서드가 실행된 것
- 이런 문제를 해결하기 위해 오버라이드 할 메서드에 virtual 키워드를 작성하자.
- 재정의 할 곳 (자식 클래스에서의 메서드)에는 override 키워드를 작성하자.

```
    class Mammal
    {
        virtual public void Move()
        {
            Console.WriteLine("이동한다.");
        }
    }
    
    class Lion : Mammal
    {
        override public void Move()
        {
            Console.WriteLine("네발로 이동한다.");
        }
    }
```

- 그렇다면 형 변환을 했더라도 오버라이드 된 메서드가 실행된다.
- 만약 오버라이드가 아닌 그냥 단순히 중복된 메서드를 만들어주고 싶다면 new 키워드를 작성하자

``` 
    class Lion : Mammal
    {
        new public void Move()
        {
            Console.WriteLine("네발로 이동한다.");
        }
    }
```

### 오버로드
- 메서드 오버로드는 java와 별반 다르지 않기 때문에 기록할 필요는 없다고 판단<br>
  따라서 연산자 오버로드만 기록할 것(사실 자바에도 존재한걸로 기억하나 까먹어서 기록..)
- 그 전에 새로운 용어를 봤기때문에 하나만 정리하고 넘어가자
- 메서드 시그니쳐 : 어떤 메서드를 고유하게 규정할 수 있는 정보를 의미<br>
  간단하게 메서드 시그니처가 동일하다는 뜻은 메서드가 같다라는 뜻(그렇게 중요하진 않은거같은데..)

#### 연산자 오버로드

```
public staitc 타입 operator 연산자(타입 변수명 ...){타입을 반환할 코드}
```
- 단항, 이항, 비교(반드시 쌍으로 재정의)는 바로 오버로딩이 가능
- (Type)x 와 같은 형변환 연산자 자체인 괄호는 오버로드 할 수 없지만<br>
  explicit, implicit를 이용해 대체 정의가 가능
- 복합 대입 연산자, 논리 연산자 및 기타 연산자는 불가능
- 배열 인덱스 연산자([]) 자체는 불가능하지만 인덱서라는 구문을 이용할 수 있음

### 클래스 간의 형변환(explicit, implicit 사용)

- 형변환은 충분하지 않나 생각하지 싶지만 위에 explicit, implicit를 설명하기 위함이니 기록하겠다.
- 이건 글로 적기가 애매한 부분이라 소스를 먼저 적고 설명하는게 나을 것 같다.
```
    public class Currency
    {
        decimal money;
        public decimal Money { get { return money; } } // get 키워드 사용함으로써 getter를 손쉽게 사용

        public Currency(decimal money)
        {
            this.money = money;
        }
    }

    public class Won : Currency
    {
        public Won(decimal money) : base(money){ } // 부모 생성자의 인스턴스를 가져옴으로써 중복 코드 제거

        public override string ToString() // 오버라이딩
        {
            return Money + "원";
        }
    }

    public class Yen : Currency
    {
        public Yen(decimal money) : base(money) { }

        public override string ToString()
        {
            return Money + "엔";
        }
    }

    public class Dollar : Currency
    {
        public Dollar(decimal money) : base(money) { }

        public override string ToString()
        {
            return Money + "달러";
        }
    }

Won won = new Won(1000);
Dollar dollar = new Dollar(1);
Yen yen = new Yen(13);
```
- 단순히 간단한 소스코드를 적었다. 각각 객체를 만들면서 가격을 넣고 ToString() 메서드를 실행하면 <br>
  각각 적어놓은 값이 출력된다.
- 여기서 형변환을 이용하여 환율을 적용한 다른 나라의 금액을 알고싶다면 (엔화에서 원화로 변경하고 싶다면) ?
```
    public class Currency
    {
        -- 생략 --

        static public implicit operator Won(Yen yen){ // 연산자 오버로딩 + implicit 연산자 사용
            return new Won(yen.Money * 13m);
        }
    }

Won won1 = yen; // 암시적(implicit) 형변환 가능
Won won2 = (Won)yen; // 명시적(explicit) 형변환 가능
```
- implicit은 암시적 형변환이 가능하기 때문에 암시적 형변환이 가능하면 명시적 형변환 역시 가능하다.
- 여기서 개발자가 암시적 형변환은 막고싶다면 implicit 대신 explicit 연산자를 사용하자!

### 중첩 클래스
- 말그대로 클래스 내에 클래스를 지정하는 것
- 앞에서 설명한대로 클래스를 생성할때 접근 제한자를 생략하면 internal이 지정된다.<br>
  하지만 중첩 클래스는 private로 지정되니 햇갈리지 말자.

### delegate(대리자)

- 앞에서 배운것 처럼 타입은 "값"을 담을 수 있는데 "값"의 범위에 "메서드"를 포함 시킨다면?
- delegate를 이용하여 메서드 자체를 값으로 갖는 타입이 가능하다.

```
접근제한자 delegate 대상_메서드의_반환타입 메서드명(...)
public int Clean(object args){
    ...
}

delegate int FuncDelegate(object args);
```
- 위 Clean 메서드를 값의 범위로 늘려주기위해 사용한 delegate 사용법을 나타냈다.
```
Disk disk = new Disk();

FuncDelegate cleanFunc2 = new FuncDelegate(disk.Clean);
FuncDelegate cleanFunc = disk.Clean; //c# 2.0부터 가능
```
- delegate는 인스턴스가 메서드를 호출할수 있다는 점을 제외하면 완전한 타입에 속하기 때문에<br>
  일반적인 타입 사용과 같이 사용해주면 된다.
- 지금까지 보여준 방식으로는 직접 클래스를 생성해서 메서드를 호출하나 delegate를 이용하여 호출하나 같은 방식

#### delegate 응용
- delegate를 이용하여 하나의 타입으로 여러 메서드를 한번에 호출하는 방법이 있다.(내부 타입의 MulticastDelegate)
```
class Program
{
    delegate void CalcDelegate(int x, int y);
    static void Add(int x, int y) { Console.WriteLine(x + y); }
    static void Subtract(int x, int y) { Console.WriteLine(x - y); }
    static void Mul(int x, int y) { Console.WriteLine(x * y); }
    static void Div(int x, int y) { Console.WriteLine(x / y); }

    static void Main(string[] args)
    {
        CalcDelegate calc = Add;
        calc += Subtract;
        calc += Mul;
        calc += Div;

        calc(10, 5);
    }
}
```
- 여기서 주목할건 += 인데 여기서 +=는 메서드를 추가한다는 의미이다.
- 그렇다면 -=는 해당 메서드를 제거하는 역할을 한다.
```
static void Main(string[] args)
{
    CalcDelegate calc = Add;
    calc += Subtract;
    calc += Mul;
    calc += Div;

    calc(10, 5); //Add, Subtract, Mul, Div 메서드 실행

    calc -= Div; // Div 메서드 제거
    calc(10, 5);// Add, Subtract, Mul 메서드 실행
}
```
- 사실 아직 delegate가 와닿지 않다. 다만 delegate를 이용하여 익명함수, 람다식을 이용한다면 다를 수 있지 않을까..
- delegate에 대해서는 좀 더 파고들어서 공부할 필요가 있음

### 인터페이스
- 인터페이스는 클래스와 다르게 다중 상속이 가능 클래스상속과 같은 방식으로 소스코드 작성
- 인터페이스에 선언된 메서드를 오버리이딩할때 override 예약어를 작성할 필요가 없음
- java에서 쓰던방식과 동일하나 c#에서는 다른 방식도 씀
```
class NoteBook : Computer, IMonitor
{
    void Imonitor.TurnOn(){}
}
```
- 이런 방식으로 메서드를 선언할 수 있다.(접근 제한자를 명시하지 않아도 되는 경우)
- 내가 아는 기존 방식은 반드시 접근 제한자를 명시해야 한다.(자바와 차이점)
- 접근 제한자 없이 인터페이스 메서드를 오버라이딩 한 경우 해당 메서드 호출 방식도 다르다
```
NoteBook notebook = new Notebook();
notebook.TurnOn(); // 기존 방식으로는 호출 가능하나
                      다른 방식은 컴파일 오류 발생
IMonitor mon = notebook as Imonitor; // as 키워드 사용
mon.TurnOn(); // 반드시 해당 인터페이스로 형변환해서 호출
``` 
- 인터페이스에 get/set 프로퍼티도 선언이 가능하다.
- c#에서는 인터페이스 자체는 객체 생성이 불가능하나 인터페이스 배열은 가능하다...

#### IEnumerable 인터페이스

- foreach 문법을 좀 더 넓게 사용하기 위해 IEnumerable 인터페이스를 확인해보자
- IEnumerable은 닷넷 프레임워크 내부에서 제공된다.
```
public interface IEnumerable{
    IEnumerator GetEnumerator();
}
```
- 여기서 GetEnumerator()는 IEnumerator를 반환하게 된다.
- IEnumerator 인터페이스 역시 닷넷 프레임워크 내부에서 제공된다.
```
public interface IEnumerator{
    object Current {get;} // 현재 요소를 반환
    bool MoveNext(); // 다음 순서의 요소로 넘어가도록
    void Reset(); // 열거 순서를 처음으로 되돌릴 때
}
```
- 즉 IEnumerator 인터페이스를 이용하여 foreach 구문을 돌리게 된다.
- foreach 구문은 기본 타입 또는 string타입이 지원되나 커스텀 타입(클래스)를 이용하기 위해서는 오버라이딩을 해야한다.
```
class Hardware{}
class USB{
    string name;
    public USB(string name){this.name = name;}

    public override string ToString(){
        return name;
    }
}

class NoteBook : Hardware, IEnumerable{
    USB[] usbList = new USB[] {new USB("USB1"), new USB("USB2")};

    public IEnumerator GetEnumerator(){
        return new USBEnumerator(usbList);
    }

    public class USBEnumerator : IEnumerator{
        int pos = -1; // 왜 0부터가 아닌 -1 부터냐면 MoveNext() 메서드를 먼저 진행함으로써 pos++ 되어 0으로 진행
        int length = 0; // 그 후에 Current 인스턴스를 실행함으로써 list[0]부터 반환!
        object[] list;

        public USBEnumerator(USB[] usb){
            list = usb;
            length = usb.Length;
        }

        pulbic object Current // 현재 요소를 반환
        {
            get {return list[pos];}
        }

        public bool MoveNext() // 다음 순서의 요소를 지정
        {
            if( pos >= length - 1){
                return false;
            }

            pos++;
            return true;
        }

        public void Reset() // 처음부터 열거하고 싶을 때 호출
        {
            pos = -1;
        }
    }
}
```
- 이로써 foreach문이 사용이 가능해진다.
```
Notebook notebook = new Notebook();
foreach(USB usb in notebook){
    Console.WriteLine(usb);
}
```

### 구조체
- 클래스가 참조형 타입이라면 구조체는 값 형식이다. 클래스와 유사한 방식이 있으나 클래스보단 제한적이다.
- 클래스와 차이점을 설명해보자면
```
1. 인스턴스 생성할때(객체를 생성할때) new로 해도되고 안해도 된다.
2. 기본 생성자는 명시적으로 정의 불가능
3. 매개변수를 갖는 생성자를 정의해도 기본생성자가 c# 컴파일러에 의해 자동으로 포함(클래스는 x)
4. 매개변수를 받는 생성자의 경우, 반드시 해당 코드 내에서 구조체의 모든 필드에 값을 할당해야 한다.
5. 구조체는 상속이 불가능(System.Object를 상속하는 System.ValueType에서 직접 상속)
```
```
struct Vector
{
    public int x;
    public int y;

    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return "x: " + x + " Y: " + y ;
    }
}
```
```
Vector v1 = new Vector(); // new를 사용해 인스턴스 생성 가능
Vector v2; // 사용안해도 가능
v2.x = 0;
v2.y = 0;

Vector v3 = new Vector(5, 10); // 명시적 생성자를 이용하여 생성 가능
```
- v1, v2, v3 모두 결과가 같다.
- 결론적으로 구조체는 값 자체를 스택에 저장(깊은 복사)<br>
  클래스는 주소값을 스택에 저장한 후 힙 메모리에 값을 불러오는 형식(얕은 복사)
- 따라서 클래스/구조체 정의는 개발자의 몫이라고 적혀는 있는데... 뭐 그렇답니다..


#### ref, out
- c#에서는 call by reference(참조에 의한 호출)을 위한 예약어 ref, out을 지원한다.
- ref, out 예약어는 얕은 복사를 진행한다는 점을 기억하자.
- 사용법은 호출할 메서드 매개변수 앞에 예약어를 작성한다.(메서드 선언부에도 똑같이 적용)

- out 예약어는 ref에 비해 제한적, 즉 몇가지 기능을 강제로 제한한다.
    - out으로 지정된 인자에 넘길 변수는 초기화되지 않아도 된다.<br>
     초기화가 되어있더라도 out 인자를 받는 메서드에서는 그 값을 사용 할 수 없다.
    - out으로 지정된 인자를 받는 메서드는 반드시 벼누에 값을 넣어서 반환해야 한다.
```
bool Divide(int n1, int n2, out int result){
    if(n2 == 0){
        result = 0; // return 하기 전 반드시 초기화 해야함!
        return false;
    }

    result = n1 / n2;
    return true;
}

int quotient;
if(Divide(15, 3, out quotient) == true){ // out 인자를 넣을때 초기화를 안해도 되며 하더라도 초기화가 안된 인자가 들어감!
    Console.WriteLine(quotient);
}
```

- 이와 비슷한 용도로 닷넷 프레임워크에서는 TryParse 메서드를 제공한다.
```
public static bool TryParse(string s, out int result);
```

```
int n; // int형으로 형 변환이 가능한지 체크해주는 유용한 기능이며 즉시 형변환도 가능!
if(int.TryParse("1234567",out n) == true){
    Console.WriteLine(n);
}
```

### enum
```
enum Days{
    Sunday, Monday, Tuesday, Wednesday, Thrusay, Friday, Saturday
}

Days workingDays = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thrusay | Days.Friday | Days.Saturday | days.Sunday;

Console.WriteLine(workingDays.HasFlag(Days.Sunday)); // 해당 Flag가 포함되어 있는가?
Console.WriteLine(workingDays); // 해당 값의 합이 결과값
```
- 여기서 woringDays의 값을 0+1+2+3+4+5+6 = 21이 나온다.
- 하지만 개별 정수가 의미가 있는 특성을 묶은 enum의 특성상 출력값이 Sunday...로 나오게 하고 싶다면?

```
[Flags] // flags 특성을 붙이자 (c#은 다양한 종류가 지원이 된다...)
enum Days{
    Sunday, Monday, Tuesday, Wednesday, Thrusay, Friday, Saturday
}
```

### 멤버 유형 확장
- 클래스에서 기본적으로 제공되는 멤버 유형은 필드와 메서드
- 프로퍼티는 메서드의 변형이며, 델리게이트는 중첩 클래스의 변형

#### readonly
- 말 그대로 읽기만 가능하게 설정하는 예약어
- 클래스에 필드를 선언할때 앞에 붙여준다. 이 기능은 클래스 내부에서도 읽기만 가능하다.

#### const
- 말 그대로 상수! 앞에 const를 사용하면 그 필드 값은 상수가 된다.
- static을 붙일 수 없으나 static 인스턴스와 비슷하다고 생각하자.

#### evnet
- '간편 표기법' 중 하나로 다음 조건을 만족하는 정형화된 콜백 패턴을 구현하려고 할 때 이 예약어를 사용

```
1. 클래스에서 이벤트(콜백)를 제공한다.
2. 외부에서 자유롭게 해당 이벤트(콜백)를 구독하거나 해지하는 것이 가능
3. 외부에서 구독/해지는 가능하나 이벤트 발생은 오직 내부에서만 가능
4. 이벤트(콜백)의 첫 번째 인자로는 이벤트를 발생시킨 타입의 인스턴스
5. 이벤트(콜백)의 두 번째 인자로는 해당 이벤트렝 속한 의미 있는 값이 제공된다.
```

- 콜백을 구현하기 위한 소수 생성기를 구현해보자
```
namespace _4.OOP_4
{

    class CallbackArg { } // 콜백의 값을 담는 클래스의 최상위 부모 클래스 역할

    class PrimeCallbackArg : CallbackArg // 콜백 값을 담는 클래스 정의
    {
        public int Prime;

        public PrimeCallbackArg(int Prime)
        {
            this.Prime = Prime;
        }
    }

    // 소수 생성기: 소수가 발생할 때마다 등록된 콜백 메서드 호출
    class PrimeGenerator
    {
        // 콜백을 위한 델리게이트 타입 저의
        public delegate void PrimeDelegate(object sender, CallbackArg arg);

        // 콜백 메서드를 보관하는 델리게이트 인스턴스 필드
        PrimeDelegate callbacks;


        // 콜백 메서드 추가
        public void AddDelegate(PrimeDelegate callback)
        {
            callbacks = Delegate.Combine(callbacks, callback) as PrimeDelegate;
        }

        // 콜백 메서드 삭제
        public void RemoveDelegate(PrimeDelegate callback)
        {
            callbacks = Delegate.Remove(callbacks, callback) as PrimeDelegate;
        }

        // 소수 발견되면 콜백 메서드 호출
        public void Run(int limit)
        {
            for (int i = 2; i <= limit; i++)
            {
                if (IsPrime(i) == true && callbacks != null)
                {
                    // 콜백을 발생시킨 측의 인스턴스와 발견된 소수를 콜백 메서드에 전달
                    callbacks(this, new PrimeCallbackArg(i));
                }
            }
        }

        // 소수 판정 메서드
        private bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (int i = 3; (i * i) <= candidate; i++)
            {
                if ((candidate % i) == 0) return false;
            }

            return candidate != 1;
        }
    }

    class Program
    {
        // 콜백으로 등록될 메서드 1
        static void PrintPrime(object sender, CallbackArg arg)
        {
            Console.Write((arg as PrimeCallbackArg).Prime + ", ");
        }

        static int Sum;

        // 콜백으로 등록될 메서드 2
        static void SumPrime(object sender, CallbackArg arg)
        {
            Sum += (arg as PrimeCallbackArg).Prime;
        }
        static void Main(string[] args)
        {
            PrimeGenerator gen = new PrimeGenerator();

            // 콜백으로 등록될 메서드 1 추가
            PrimeGenerator.PrimeDelegate callprint = PrintPrime;
            gen.AddDelegate(callprint);

            // 콜백으로 등록될 메서드 2 추가
            PrimeGenerator.PrimeDelegate callsum = SumPrime;
            gen.AddDelegate(callsum);

            gen.Run(10);
            Console.WriteLine();
            Console.WriteLine(Sum);

            gen.RemoveDelegate(callsum);
            gen.Run(15);
        }
    }
}
```

- 이제 evnet를 사용해 예제를 간결하게 만들어 보자.
- PrimeCallbackArg 타입이 상속받는 CallbackArg 타입이 필요없다.<br>
  이미 System.EventArgs라는 타입이 닷넷 프레임워크에 제공되어 있다.

```
    class PrimeCallbackArg : EventArgs // 콜백 값을 담는 클래스 정의
    {
        public int Prime;

        public PrimeCallbackArg(int Prime)
        {
            this.Prime = Prime;
        }
    }
```
- 따라서 콜백 메서드에 전달되는 인자를 EventArg로 변경하자.
```
    // 콜백으로 등록될 메서드 1
    static void PrintPrime(object sender, EventArgs arg)
    {
        Console.Write((arg as PrimeCallbackArg).Prime + ", ");
    }

    static int Sum;

    // 콜백으로 등록될 메서드 2
    static void SumPrime(object sender, EventArgs arg)
    {
        Sum += (arg as PrimeCallbackArg).Prime;
    }
```
- 다음으로 event 예약어의 위력이 발휘될 차례다. PRimeGenerator 타입에 구현되어 있는 PRimeDelegate, <br>
  AddDelegate, RemoveDelegate 멤버를 제거하고 다음의 한 줄로 정의하면 된다.
```
public event EventHandler PrimeGenerated; // event!
```
- callbacks 인자의 이름이 이벤트의 PrimeGenerated로 바뀌었으므로 Run 메서드의 코드도 변경하자.
```
    public void Run(int limit)
    {
        for (int i = 2; i <= limit; i++)
        {
            if (IsPrime(i) == true && PrimeGenerated != null)
            {
                // 콜백을 발생시킨 측의 인스턴스와 발견된 소수를 콜백 메서드에 전달
                PrimeGenerated(this, new PrimeCallbackArg(i));
            }
        }
    }
```
- 여기까지가 PrimeGenerator에서 이벤트를 제공하기 위한 코드의 전부이다.
- 이렇게 제공되는 이벤트를 사용하는 측은 이전보다 더욱 간결하게 이벤트 구독/해지를 할 수 있다.
```
    static void Main(string[] args)
    {
        PrimeGenerator gen = new PrimeGenerator();

        gen.PrimeGenerated += PrintPrime;
        gen.PrimeGenerated += SumPrime;

        gen.Run(10);
        Console.WriteLine();
        Console.WriteLine(Sum);

        gen.PrimeGenerated -= SumPrime;
        gen.Run(15);
    }
```

#### Indexer
```
int[] intArray = new int[5];
intArray[0] = 6;
```
- 배열의 0번째 요소에 접근할 때 대괄호 연산자를 사용한다.
- 하지만 배열이 아닌 일반 클래스에서 이런 구문을 사용하기위해 인덱서라고 하는 특별한 구문을 제공한다.

```
class 클래스명
{
    접근제한자 반환타입 this[인덱스타입 인덱스명]{
        접근제한자 get{
            ...
            return 말하지 않아도 알겠...;
        }
        접근제한자 set{
            ...
        }
    }
}
인덱서를 이용하면 클래스의 인스턴스 변수에 배열처럼 접근하는 방식의 대괄호 연산자를 사용할 수 있다.
프로퍼티를 정의하는 구문과 유사하며, 단지 프로퍼티명이 this 예약어로 대체된다는 점과 인덱스로 별도의 타입을 지정할 수 있다는 점이 다르다.
```

- 다음은 Int32 정수형 데이터의 특정 자릿수를 인덱서를 사용해 문자(char) 데이터로 다룰 수 있는 예제다.
```
namespace _4.OOP_5
{
    class IntegerText
    {
        char[] txtNumber;

        public IntegerText(int number)
        {
            // Int32 타입을 System.String으로 변환하고 다시 String에서 char 배열로 변환
            this.txtNumber = number.ToString().ToCharArray();
        }

        // 인덱서를 이용해 숫자의 자릿수에 따른 문자를 반환하거나 치환
        public char this[int index]
        {
            get
            {
                // 1의 자릿수는 숫자에서 가장 마지막 단어를 뜻하므로 역으로 인덱스를 다시 계산
                return txtNumber[txtNumber.Length - index - 1];
            }
            set
            {
                // 특정 자릿수를 숫자에 해당하는 문자로 치환 가능
                txtNumber[txtNumber.Length - index - 1] = value;
            }
        }

        public override string ToString()
        {
            return new string(txtNumber);
        }

        public int ToInt32()
        {
            return Int32.Parse(ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IntegerText aInt = new IntegerText(123456);

            int step = 1;
            for (int i = 0; i < aInt.ToString().Length; i++)
            {
                Console.WriteLine(step + "의 자릿수: " + aInt[i]);
                step *= 10;

                aInt[3] = '5';
            }
            Console.WriteLine(aInt.ToInt32());
        }
    }
}
```
- 인덱서를 통해 클래스가 직관적으로 배열처럼 다뤄질 수 있을 때 편리하게 사용할 수 있다는 것을 확인했다.
- 하지만 클래스가 배열처럼 다뤄질 수 있다는 사실을 직관적으로 받아들이지 않는다.
- 그래서 다소 사용빈도가 낮은 편이라고 한다. 즉 직관적이지 않으면 사용을 굳이 할 필요는 없다는 설명인듯 ...
-----------------------------------
## c# 1.0
- 앞에 내용도 c# 1.0 또는 2.0의 일부를 기록하긴 했으나 이번 파트에선 좀 더 세부적인 내용을 기록할 예정이다.

### 특성
- 간단하게 java의 annotation과 비슷한 느낌을 받는다.

#### 사용자 정의 특성
```
class AuthorAttribute : System.Attribute{ // 반드시 Attribute를 상속

}
```
```
[AuthorAttribute] // 보통 접미사에 Attribute를 붙인다고 한다.
class Dummy1 {}

[Author] // c#에서는 접미사를 생략해도 된다.
class Dummy2 {}

[Author()] // 생성자를 표현하는 구문도 있다.
class Dummy3 {}
```
- 특성 클래스에 매개변수가 포함된 생성자를 추가할 수도 있다.
```
class AuthorAttribute : System.Attribute{
    string name;
    int _version;

    public AuthorAttribute(string name){
        this.name = name;
    }

    public int Version{
        get{return _version;}
        set{_version = value;}
    }
}

[Author("Anders", Version = 1)] // Version 속성이 생성자에 명시되어 있지 않으므로 "이름 = 값" 형식으로 전달
class Program{
    static void Main(string[] args){}
}
```

#### 특성이 적용될 대상을 제한

- 닷넷에서는 특성의 용도를 제한할 목적으로 System.AttributeUsageAttribute라는 또다른 특성을 제공한다.
- AttributeTargets에 정의된 값을 보면 특성을 적용될 수 있는 대상을 확인할 수 있다.

AttributeTargets 값 | 의미
|-------------------|---|
Assembly | 어셈블리가 대상
Module | 모듈이 대상
Class | 클래스가 대상
Struct | 구조체가 대상
Enum | 열거형 대상
Constructor | 생성자 대상
Method | 메서드 대상
Property | 프로퍼티 대상
Field | 필드 대상
Event | 이벤트 대상
Interface | 인터페이스 대상
Parameter | 매서드의 매개변수 대상
Delegate | 대리자 대상
ReturnValue | 메서드의 반환값 대상
GenericParameter | c# 2.0에 추가된 제네릭 매개변수 대상
All | AttributeTargets에 정의된 모든 대상

- 앞에서 만든 Author 특성은 전부 적용된다. 만약 메서드와 클래스에만 적용하고 싶다면
```
[AtributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class AuthorAttribute : System.Attribute
...생략...
```
- 특성을 사용하는 대괄호 구문에는 특성이 적용될 대상을 명시하는 것이 가능하다.
```
[type: Author("Tester")]
class Program{
    [method: Author("Tester")]
    static void Main(string[] args){}
}
```
AttributeTargets 값 | [target: ....]
|-------------------|---|
Assembly | assembly
Module | module
Class | type
Struct | type
Enum | type
Constructor | method
Method | method
Property | property
Field | field
Event | envent
Interface | type
Parameter | param
Delegate | type
ReturnValue | return
GenericParameter | typevar

- AttrivuteUsage 특성에는 생성자로 입력받는 AttributeTargets 말고 두가지 속성이 더 제공된다.

속성 타입 | 속성 이름 | 의미
---------|-----------|----
bool|AllowMutiple|대상에 동일한 특성이 다중으로 정의 가능(기본 false)
bool|Inherited| 특성이 지정된 대상을 상속받는 타입도 자동으로 부모의 특성을 물려받음(기본 false며 잘 안쓰임)

```
[Author("Anders", Version = 1)]
[Author("Brad", Version = 2)] // 다음과 같이 다중지정 시 "특성이 중복되었습니다." 라는 컴파일 오류 발생
class Program{}
```
- 따라서 AttributeUsage 설정 시 AllowMiltiple 속성을 true로 지정해야 한다.
```
[AtributeUsage(AttributeTargets.All, AllowMultiple = true)]
Class AuthorAttribute : System.Attribute
... 생략 ...
```
- 만약 AllowMultiple에 상관없이 여러개의 특성을 지정하는것은 가능하다.
```
[Flags]
[Author("Anders")]
enum Days{...생략...}

[Flags, Author("Anders")] // 이런식의 정의도 가능
```

### 예약어

#### 연산 범위 확인: checked, unchecked

- 오버플로우, 언더플로우가 발생하였을때 사용하는 예약어
```
short c = 32767;

checked {
    c++; // OverflowException 발생
}

unchecked {
    c++; // 컴파일러에 /checked 옵션을 적용해 컴파일된 경우에도 오류가 발생하지 않는다.
}
```

#### 가변 매개변수: param

- 메서드를 정의할 때 며개의 인자를 받아야 할지 정할 수 없을 경우 사용
```
static int Add(params int[] values){
    int result = 0;

    for(int i = 0; i < values.Length; i++){
        result += values[i];
    }
    return result;
}
```

### 응용 프로그램 구성 파일 : app.config

#### supportedRuntime

- 닷넷 프레임워크를 지원하기 위한 태그 속성
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7" />
        <supportedRuntime version="v2.0.50727"/> // 다중지원하려면 이런식으로 추가로 작성하자
    </startup>
</configuration>
```

#### appSettings
- supportedRuntime은 CLR의 초기화에 관여하므로 app.config에 지정할 수밖에 없는 경우였다.
- 반면 appSettings는 CLR보다는 그 위에서 실행되는 응용 프로그램에 값을 전달하는 목적으로 사용한다.
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <appSettings>
        <add key="adminEmailAddress value="admin@sysnet.pe.kr"/>
        <add key="Delay" value="5000"/>
    </appSettings>
</configuration>
```
- key에는 설정값을 구분할 수 있는 이름, value는 key로 식별되는 값을 준다.
- app.config에 지정한 값을 c# 코드에서 읽어들여 활용할 수 있다.
```
namespace _5.c__1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = ConfigurationSettings.AppSettings["AdminEmailAddress"];
            Console.WriteLine(txt); // admin@sysnet.pe.kr

            txt = ConfigurationSettings.AppSettings["Delay"];
            int delay = int.Parse(txt);
            Console.WriteLine(delay); // 5000
        }
    }
}
```
- ConfigurationSettings 타입은 System.configuration 네임스페이스로 System.dll에 정의된 타입이다.
- appSettings에 지저된 값을 가져올 수 있는 AppSettings 정적 멤버가 제공된다.
- appSettings는 소스코드를 재컴파일하지 않고도 프로그램의 일부 동작을 사용자로 하여금 변경할 수 있는 장점이 있다.<br>
  예를 들어 이메일을 변경할때 app.config에서 value를 변경하면 끝!

### DEBUG, TRACE 전처리 상수
- 디버그 빌드와 릴리스 빌드를 할 때 VS에서는 자동으로 관리되는 전처리 상수가 있다.
- 릴리스 빌드일때 TRACE만 지정, 디버그 빌드일때 DEBUG, TRACE 둘다 지정
- 이런 차이를 이용하여 디버그 빌드일때만 사용하는 소스코드를 지정 할 수 있다.

#### Conditional
- 전처리 상수를 이용하여 기존 #if, #endif를 이용하여 디버그 빌드일때만 사용하는 소스코드를 지정할 수 있다.
- 하지만 Conditional 특성을 이용하면 좀 더 간단해진다.
```
static void Main(string[] args){
    OutputText();
}

[Conditional("DEBUG")]
static void OutputText(){
    Console.WriteLine("디버그 빌드");
}
``` 
### 예외처리

#### thorw; vs throw ex; 차이점
- thorw ex;만 하면 해당 ex코드가 발생한 지점부터 호출스택이 남는다. 즉 그 지점만 오류내용이 호출
- throw; 는 예외를 발생시킨 모든 호출 스택이 출력