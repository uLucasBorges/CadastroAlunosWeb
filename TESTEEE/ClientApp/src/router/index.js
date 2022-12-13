import { createWebHistory, createRouter } from "vue-router";
import Professores from "@/components/Professores.vue";
import AlunoDetalhe from "@/components/AlunoDetalhe.vue";
import AlunosVue from "../components/Alunos.vue";
import AlunosP from "../components/AlunosPP.vue";
import CadastrarAluno from "../components/CadastrarAluno.vue";

const routes = [
    {
        path: "/alunoss",
        name: "alunoss",
        component: AlunosVue,
    },
    {
        path: "/Professores",
        name: "Professores",
        component: Professores,
    },
    {
        path: "/alunoDetalhe/:id",
        name: "AlunoDetalhe",
        component: AlunoDetalhe,
    },
    {
        path: '/alunos/:prof_id',
        name: 'Alunos',
        component: AlunosP
    },
    {
        path: "/Cadastrar",
        name: "Cadastrar",
        component: CadastrarAluno,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;