import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'

var server = Axios.create({
  baseURL: "//localhost:5000/api/"
})

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    burgers: [],
    burger: {}
  },
  mutations: {
    setBurgers(state, burgers){
      state.burgers = burgers;
    },
    setBurger(state, burger){
      state.burger = burger
    }
  },
  actions: {
    getAllBurgers({ commit, dispatch }) {
      server.get('burgers')
      .then(res=>{
        commit('setBurgers', res.data)
      })
    },
    getBurgerById({ commit, dispatch }, id) {
      server.get("burgers/" + id)
      .then(res=>{
        commit('setBurger', res.data)
      })
    },
    createBurger({commit, dispatch}, burger){
      server.post('burgers', burger)
      .then(res=>{
        dispatch('getAllBurgers')
      })
    },
    updateBurger({commit, dispatch}, id, burger){
      server.post('burgers/' + id, burger)
      .then(res=>{
        dispatch('getAllBurgers')
      })
    },
    deleteBurger({dispatch}, id) {
      server.delete('burgers/' + id)
      .then(res=>{
        dispatch('getAllBurgers')
      })
    },
  }
})
