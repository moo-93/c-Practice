# c# 연습

- 입사할 회사의 주요 언어가 c#, asp.net이므로 낙서느낌으로 기록할 예정
- java와 대체로 비슷하나 다른부분 또는 새로운 부분을 기록할 예정
- 순서가 조금 어긋나서 가독성이 떨어질 염려가 있으나 지속적인 수정을 할 것

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
    * decimal은 double의 상위 단계라 생각 (double 8비트 decimal 16비트) 

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