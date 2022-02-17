pipeline {
  agent any
  stages {
    stage('Clean workspace') {
      steps {
        cleanWs(cleanWhenAborted: true, cleanWhenNotBuilt: true, cleanWhenFailure: true, cleanWhenSuccess: true, cleanupMatrixParent: true, cleanWhenUnstable: true, deleteDirs: true, disableDeferredWipeout: true)
      }
    }

    stage('Git Checkout') {
      steps {
        git(url: 'https://github.com/DanielPrzewozny/CarProject', branch: 'main', credentialsId: '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')
      }
    }

    stage('Restore packages') {
      steps {
        sh 'Write-Host "second string"'
      }
    }

  }
}