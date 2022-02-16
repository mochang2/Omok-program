# OmokProgram
##### (feat. 오목대전)
#### omok program with C#(winform)  
  
bob 10기 경연 단계 gilgil 멘토의 경연 수업  
omok program 만들기  
싱글 플레이와 멀티 플레이가 있음

-------------------------

#### 게임 시작 및 싱글/멀티 플레이를 위한 설정 화면
<img src="https://user-images.githubusercontent.com/63287638/148747152-b52fe528-943d-4502-ac4e-4f7a3c4e6261.png" width="450" height="auto" alt="game start screen" />
(게임 시작 시 나오는 화면)<br/>
싱글 플레이 또는 멀티 플레이를 선택 가능.<br/>
<br/>
<br/>
<img src="https://user-images.githubusercontent.com/63287638/154199285-0f9435e6-cb1d-46a4-8c00-5868ab93f3d1.png" width="450" height="auto" alt="singleplay option screen" />   
(싱글 플레이 선택 시 나오는 옵션 화면)<br/>
렌주룰 기반 bob-10룰을 사용.  AI 단계는 1~10단계까지 있으나 현재는 같은 모듈을 사용중.<br/>
사용자는 흑돌을 잡을 것인지, 백돌을 잡을 것인지 선택 가능.<br/>
<br/>
<br/>
<img src="https://user-images.githubusercontent.com/63287638/154199552-842d5edd-94f2-465d-9065-c42037060cb5.png" width="450" height="auto" alt="multiplay option screen" />  
(멀티 플레이 선택 시 나오는 옵션 화면)<br/>
AI vs AI 간의 멀티플레이만 지원<br/>
서버의 IP와 Port를 입력해서 접속 가능. 기본적으로 localhost의 1234번 포트로 설정되어 있음.<br/>
멀티 플레이를 위한 프로토콜은 bob-10 프로토콜을 사용함.<br/>
해당 프로토콜과 서버는 <a href="https://github.com/NownS/bob10-gomoku"><b>[여기]</b></a> 에 자세히 있음.

-------------------------

#### 싱글 플레이 화면
<img src="https://user-images.githubusercontent.com/63287638/154200731-2ecc1c97-2a2c-4939-be2f-7a5ee2e0abe3.png" width="450" height="auto" alt="singleplay screen" />   
<ul>
  <li>우측 상단에 본인과 AI의 색깔 표시</li>
  <li>본인 차례에 화면을 눌러 착수하고 싶은 위치를 지정 후 우측 하단 "착수" 버튼을 누르면 착수 가능</li>
  <li>우측에 남은 시간 표시(제한 시간 15초)</li>
  <li>15초 이내로 착수하지 않은 경우 AI의 차례로 넘어감</li>
  <li>"기권" 버튼을 누르면 AI의 승</li>
  <li>15 by 15 오목판이 전부 꽉 찼는데도 결과가 나지 않으면 무승부</li>
  <li>경기가 끝난 이후 "착수" 및 "기권" 버튼 위치에 본인이 이겼는지, 졌는지, 무승부인지 결과를 표시</li>
  <li>흑에 대한 금수 위치가 나오면 화면에 금수 위치 표시</li>
  <li>금수 룰은 <a href="https://github.com/mochang2/Omok-program/edit/master/README.md#%EC%B0%B8%EA%B3%A0%EC%82%AC%ED%95%AD"><b>[여기]</b></a></li>
  <li>오목판에 착수 순서가 표시됨</li>
 </ul>

-------------------------

#### 멀티 플레이 화면
<img src="https://user-images.githubusercontent.com/63287638/154201218-9e853dee-6cc4-40ee-bee5-d26da76d0885.png" width="450" height="auto" alt="multiplay screen" />   
<ul>
  <li>우측 및 오목판에 착수 순서 표시</li>
  <li>현재 착수 순서를 우측에서 색깔로 표시</li>
  <li>패배 조건
    <ol>
      <li>AI가 15초 이내로 착수하지 않는 경우</li>
      <li>Client 측에서 crash가 나서 연결이 끊기는 경우</li>
      <li>이미 착수된 위치에 다시 착수하는 경우</li>
      <li>흑일 경우 금수 위치에 두는 경우</li>
    </ol>
  </li>
  <li>경기가 끝난 이후 결과 표시</li>
  <li>흑에 대한 금수 위치가 나오면 화면에 금수 위치 표시</li>
  <li>금수 룰은 싱글 플레이와 동일</li>
 </ul>

-------------------------

#### 참고사항
1. 룰은 흑돌 33, 44 금지룰. 단, 연결되고 열린 33, 44에 대해서만 금지. 흑돌은 장목해도 패배하진 않지만 승리도 아님. 백돌은 장목해도 승리.
2. AI의 알고리즘은 룰 기반 가중치 적용 알고리즘. Minimax와 크게 다르진 않지만 상대방의 수를 예측하진 않음. depth가 깊으면 15초 이내로 계산을 못해서 Minimax 사용하지 않음.
3. 사용법<br/>
```
git clone https://github.com/mochang2/Omok-program.git
이후 vscode 실행 -> 빌드 -> 실행
```
