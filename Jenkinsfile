node {

    def mvnHome
    def commitId
    
    stage('preparation') { 
        checkout scm
        commitId = sh(returnStdout: true, script: 'git rev-parse HEAD')
    }

    stage('restore') {
        sh 'dotnet restore --configfile NuGet.config'
    }

    stage('build'){
        sh 'dotnet build'
    }

    stage('publish'){
        sh 'dotnet publish -c Release'
    }

    stage('tests') {
        sh 'dotnet test'
    }

    if(env.BRANCH_NAME == 'master'){
        stage('package'){
            dir('Stack.DataContext/'){
                withCredentials([string(credentialsId: 'NexusNuGetToken', variable: 'token')]) {
                    mvnHome = env.BUILD_NUMBER 
                    packageN = "2.1.${mvnHome}"
                    sh "dotnet pack -p:PackageVersion=${packageN} -c Release -o ./"
                    sh "dotnet nuget push -s https://nexus.qaybe.de/repository/nuget-hosted/ -k ${token} ./*${packageN}.nupkg"
                }
            }   
        }
    }

    stage('clean'){
         cleanWs()
    }
}
