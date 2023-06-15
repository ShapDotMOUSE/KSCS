# Kw Schedule Calendar Service
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
</div>
</details>

<details>
<summary>로그인 세션 유지</summary>
<div markdown="1">       
</div>
</details>

<details>
<summary>Klas 연동을 통한 학사일정</summary>
<div markdown="1">       
</div>
</details>

<details>
<summary>오늘의 일정 & 마감 일정</summary>
<div markdown="1">       
</div>
</details>

<details>
<summary>공유 일정</summary>
<div markdown="1">       
</div>
</details>

<details> 
<summary>일정 보기 탭 & 카테고리</summary>
<div markdown="1">       
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
