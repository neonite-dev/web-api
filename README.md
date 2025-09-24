# Git브랜치 정책

## 주요 브랜치
    1. master
        - 기본으로 만들어지는 브랜치로 실제 서비스 환경으로 배포됨
    2. dev
        - 개발 환경으로 배포되는 브랜치
    3 .stage
        - stage 환경으로 배포되는 브랜치
    4. feature / id / pms번호
        - 각 개발자가 개발하는 브랜치로 작업 완료 후 dev 브랜치로 PR(Pull Request) 후 병합(merge) 하고 삭제


## 개발 순서
    1. 개발자는 master 브랜치로 부터 feature 브랜치를 생성 개발 진행
    2. 개발 완료 후  dev 브랜치로 MR 생성
    3. 요청된  MR 소스 리뷰 진행 ( 관리자) 
    4. 소스 리뷰 완료 후  dev 브랜치로 병합 진행
    5. stage 배포를 위해 dev 브랜치 stage 브랜치로 병합
    6. 실서버 배포를 위해 stage 브랜치 master 브랜치로 병합
    7. master 브랜치로 실서버 배포 진행


## 소스 병합순서 
    feature -> dev -> stage -> master 순서임
