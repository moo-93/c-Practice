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