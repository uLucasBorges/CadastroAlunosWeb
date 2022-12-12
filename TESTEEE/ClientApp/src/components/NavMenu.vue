<template>
    <div class="barraTop"  v-if="this.$router === 'login' || this.$router === '/login'">
        <nav class="marginPrincipal">
            <router-link to="/professores"> Professores</router-link>
            <router-link to="/alunoss"> Alunos</router-link>
            <router-link to="/cadastrar"> Cadastrar Alunos</router-link>
        </nav>
    </div>
</template>

<script>
    export default {


    }

</script>

<style scoped>


</style>