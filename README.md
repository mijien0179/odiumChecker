# odiumChecker
메이플스토리가 종료되고나서야 일퀘 했는지 뒷북치는 알리미

#### 다운로드
https://github.com/mijien0179/odiumChecker/releases/tag/v1.0

#### Youtube
이미지 클릭시 시연 영상 Youtube로 이동합니다.
[![Untitled_1 3 1](https://user-images.githubusercontent.com/40613626/208830689-ae27f93f-d07c-49f5-942d-61459bdb891c.png)](https://youtu.be/7SvIDnwGuho)

## 개발 정보
- Windows 10
- Visual Studio 2022 v17.4.2
- .NET 6 C#
- Ryzen7 5800X / 64G RAM
- GTX 1660 SUPER 6G


## 개요
메이플스토리가 관리자 권한으로 실행하는 프로그램이라서, 실행 여부를 확인하려면 관리자 권한이 필요한 것으로 알고 있습니다. 때문에 본 프로그램 또한 관리자 권한으로 실행됩니다.  
컴퓨터와 함께 시작하도록 설정한 경우, 작업 스케줄러의 odium/autorun에 등록되어 시스템에서 실행시킵니다.  
<img width="932" alt="image" src="https://user-images.githubusercontent.com/40613626/208829616-15b5b7c9-9593-491c-927a-76fada41340d.png">


## 상세
컴퓨터와 함께 시작을 체크해야 알리미가 활성화됩니다.  
![image](https://user-images.githubusercontent.com/40613626/208829111-32b1c508-90ac-4d47-8acd-d92c17fe279e.png)

활성화된 알리미는 메이플스토리가 시작된 후부터 종료때까지를 탐지한 후, 실행이 종료되었다 판단이 되면 화면 가운데 안내 창을 띄웁니다.  
![image](https://user-images.githubusercontent.com/40613626/208829887-a70c0a68-a151-41a1-a3aa-0cbaa1fd8fd8.png)  
> 버튼
> - 했음: 실수 방지를 위해 키보드 `Ctrl키를 누른 상태에서 마우스 클릭 시 안내 창이 닫힙니다.` 프로그램은 종료되지 않습니다.
> - 안했음: 안내창이 닫히며 메이플스토리 홈페이지로 이동합니다.

### 참고
작업 표시줄의 어센틱심볼:오디움 아이콘을 우측 마우스 클릭해 종료할 수 있습니다.  
![image](https://user-images.githubusercontent.com/40613626/208829858-a03870e0-1b38-4773-8738-7e5116f4416b.png)
