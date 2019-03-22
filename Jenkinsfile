node {

    def mvnHome
    def commitId
    properties([gitLabConnection('GitLab')])
    
    stage('preparation') { 
        checkout scm
        commitId = sh(returnStdout: true, script: 'git rev-parse HEAD')
        updateGitlabCommitStatus name: 'restore', state: 'pending', sha: commitId
        updateGitlabCommitStatus name: 'build', state: 'pending', sha: commitId
        updateGitlabCommitStatus name: 'publish', state: 'pending', sha: commitId
        updateGitlabCommitStatus name: 'test', state: 'pending', sha: commitId
        if(env.BRANCH_NAME == 'master'){
           updateGitlabCommitStatus name: 'package', state: 'pending', sha: commitId
        }
        updateGitlabCommitStatus name: 'clean', state: 'pending', sha: commitId
    }

    stage('restore') {
        gitlabCommitStatus("restore") {
			sh 'dotnet restore'
		}
    }

    stage('build'){
        gitlabCommitStatus("build") {
			sh 'dotnet build'
		}
    }

    stage('publish'){
		gitlabCommitStatus('publish'){
			sh 'dotnet publish -c Release'
		}
    }

    stage('tests') {
        gitlabCommitStatus("test") {
            sh 'dotnet test'
        }
    }

    if(env.BRANCH_NAME == 'master'){
        stage('package'){
            gitlabCommitStatus('package'){
                mvnHome = env.BUILD_NUMBER 
                packageN = "0.0.${mvnHome}"
                sh "dotnet pack -p:PackageVersion=${packageN} -c Release -o ./"
                sh "dotnet nuget push -s https://nexus.qaybe.de/repository/nuget-hosted/ -k f4aa7680-0f0a-3d31-90c4-97e840c221f5 ./*${packageN}.nupkg"
            }
        }   
    }

    stage('clean'){
        gitlabCommitStatus("clean") {
			cleanWs()
	   }	
    }
}
