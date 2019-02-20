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
#### foreach(표현식요소의_자료형 변수명 in 표현식)
    ex) foreach(int elem in arr)
------------------------

## c# 객체지향 문법

#### namespace(이름공간)
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

#### 접근 제한자

- c#에서의 접근 제한자는 5가지로 정해져있다.
    - private, protected, public, internal, internal protected
    - internal : 동일한 어셈블리 내에서는 public에 준한 접근을 허용
    - internal protected : 동일 어셈블리 내에서 정의된 파생 클래스까지만 접근 허용
- 자바와 다르게 명시되지 않은 경우가 각각 다르다.
    - class 생략 경우 internal
    - class 내부 멤버에 대해서는 private


#### 프로퍼티
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
#### 상속
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

#### 형변환
##### as, is연산자
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

#### System.Object

##### GetType
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

###### GetHashCode
- 자바와 다르게 c#은 Get을 붙인다 참고하자

#### System.Array

##### Array

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

##### this
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

##### base
- java에선 super와 같은 뜻으로 사용되는걸 참고