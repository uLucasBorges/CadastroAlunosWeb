<template>
    <div>
        <h1>{{titulo}}</h1>
        <p>Olá , seja bem vindo(a) a minha API, ela foi contruida utilizando Vue e .NET, o front-end foi feito através de um curso realizado na plataforma Udemy e o back-end por minha conta afim de demonstrar meu conhecimento. </p>
        <p>Meu <a href="https://github.com/uLucasBorges">Github</a>,</p>
        <p> para mais informações: </p> <br>
        <p>Confira o Meu <a href="https://www.linkedin.com/in/lucas-avelar-2a2037208/"> Linkedin</a>.</p>

        <h1>Repositórios da Aplicação.</h1>
        <p> <a href="https://github.com/uLucasBorges/ApiCadastroAlunos"> Back-End</a>.</p>
        <p> <a href="https://github.com/uLucasBorges/CadastroAlunos_Front-End"> Front-End</a>.</p>

    </div>
</template>

<script>

export default {
  components:{

  },
    data(){
        return{
          titulo: 'Sobre'
        }
    }
}
</script>

<style scoped>
</style>
