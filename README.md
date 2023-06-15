# Kwangwoon Schedule Calendar Service (KSCS)
<img width="159" alt="로고" src="https://github.com/SharpDotMOUSE/KSCS/assets/89342648/30b49977-7aed-4c78-8a9d-511475bd4b4d">

<img src="https://img.shields.io/badge/version-v1.0.0-red"/>


## 👥 팀 소개

* 나부겸
* 손창민
* 김수연
* 성명근


## 📖 프로젝트 소개

**구현 계기**
* 현재 존재하는 캘린더 프로그램에서는 학교 일정과 연동되는 기능이 없음
* 공유 일정 추가 기능이 없고, 일정 자체를 공유하고 소통하는 기능이 있는 프로그램이 현존하지 않음
* 위와 같은 문제들을 해결하고 광운대학교 학생들에게 여러 편의 기능들을 제공하기 위해 현 프로젝트를 시작
 
**구현 목표**

* 사용자에 따른 일정을 관리하고, 사용자가 놓칠 수 있는 요소들(학교 일정 관련)에 대한 정보와 일정에 관한 여러가지 편의기능을 제공

**기대 효과**

* 과제, 온라인 강의, 퀴즈 등의 놓치는 실수 빈도 감소
* 사용자 편의 일정 관리 Window 캘린더
* 공유 일정 기능을 통한 소통과 협업의 효율성 향상
* 광운대학교 재학생들의 효율적인 일정관리 윈도우 프로그램


## 🔎 기능 소개

<details>
<summary>캘린더 인터페이스</summary>
<div markdown="1">   

![캘린더 인터페이스](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/877c5062-148b-4f56-bcb5-2df30d314a60)
 
![일정 생성](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/b6598a34-16e8-4b89-b6dd-ee196d268ad1)

</div>
</details>

<details>
<summary>로그인 세션 유지</summary>
<div markdown="1">       
 
![로그인 및 자동 로그인](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/1818f4ad-159d-42ff-9f58-2de8a6e23afa)

![자동로그인](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/98e49cba-b977-4e7a-8a8b-e0ec32b4e825)



</div>
</details>

<details>
<summary>Klas 연동을 통한 학사일정</summary>
<div markdown="1">     
 
![KLAS 연동](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/42fdd0a3-ba48-4329-bf7e-a9785622f821)

 
</div>
</details>

<details>
<summary>오늘의 일정 & 마감 일정</summary>
<div markdown="1">   
 
![오늘의 일정](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/bb352d52-4ecb-4dd8-ab0d-bf32c09d2c83)

![마감일정_온라인강의](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/d6e06663-79af-417e-a839-611d738eb662)
![마감일정_과제](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/00150be1-ee4f-4524-b11f-2cd85b8792a6)
![마감일정_퀴즈](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/10be7e6f-34c3-4ec3-abdd-e34ff052aa82)
![마감일정_팀플](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/49a667b1-2145-4841-9262-32c63e14a219)

 
</div>
</details>

<details>
<summary>공유 일정</summary>
<div markdown="1">     

![공유 일정](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/7bf50a53-a36b-4f9f-9661-a8cfeeb7dc28)

![공유 일정_생성](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/a86e1ae2-6fe0-4a73-9ee0-1a0deec9d9f6)

 
</div>
</details>

<details> 
<summary>일정 보기 탭 & 카테고리</summary>
<div markdown="1">       

![보기 탭](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/ec8a78d0-085a-4de7-b722-a4ef05b1ca02)
![카테고리](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/5162d64d-7d8f-4789-84b6-d77cb8b4ed26)
![카테고리_대분류추가](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/1374dc58-3568-4c3b-9c5a-5dccf7833636)
![카테고리_소분류추가](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/e46ae487-dd22-4b50-879f-e1a047417ee0)
![카테고리 변경](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/313c6d74-8cbe-4603-bcc3-dba50c6e0b0b)


</div>
</details>

<details>
<summary>실시간 일정 공유</summary>
<div markdown="1">       
</div>
</details>

## 📃 기술 스택


### Database
* MySQL

### Framework
* .NET Framework

### Infrastructure
* AWS EC2

### Design
* Figma


## ⚙️ 시스템 아키텍처


## 📁 DB 구조

![KSCS](https://github.com/SharpDotMOUSE/KSCS/assets/89342648/c50427f3-c4da-421e-8f79-ff6469557b5a)

* `TabCategory` : `StudentTab` 와 `Category` 을 매핑해주는 중간 테이블
* `Members` : `Student` 와 `Schedule` 를 매핑해주는 중간 테이블. 공유 일정 멤버들을 나타냄


## 🗣️ 커뮤니케이션

* GitHub
* Notion
* Discord
