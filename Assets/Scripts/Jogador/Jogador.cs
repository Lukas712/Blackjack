    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using UnityEngine;

    public class Jogador
    {
        private System.Random random;
        private List<Carta> maoJogador;
        private List<Trunfo> inventario;
        private int pontosDeVida;
        private int betAtual;
        private int soma;

        private void adicionaTrunfosAleatorios(int quantidade)
        {
            Type tipoBase = typeof(Trunfo);
            for(int i = 0; i<quantidade;i+=1)
            {
                var classesDerivadas = Assembly.GetAssembly(tipoBase).GetTypes().Where(type => type.IsSubclassOf(tipoBase) && !type.IsAbstract).ToList();

                if(classesDerivadas.Any())
                {
                    Type tipoTrunfo = classesDerivadas[random.Next(classesDerivadas.Count())];

                    Trunfo instanciaTrunfo = (Trunfo)Activator.CreateInstance(tipoTrunfo);
                    inventario.Add(instanciaTrunfo);
                }
            }
        }
        public Jogador()
        {
            inventario = new List<Trunfo>();
            maoJogador = new List<Carta>();
            pontosDeVida = 10;
            betAtual = 0;
            random = new System.Random();
            adicionaTrunfosAleatorios(10);

        }
        public int getBet() { return betAtual; }
        public void setBet(int val) { betAtual = val; }

        public int getVida() { return pontosDeVida; }
        public void setVida(int val) { pontosDeVida = val; }

        public List<Carta> getMaoJogador() { return maoJogador; }
        public List<Trunfo> getInventarioJogador() { return inventario; }

        public void insereInventario(Trunfo trunfo) { inventario.Add(trunfo); }

        public void insereCarta(int val) { }

        public void removeCarta(int val) { }
        public bool passarVez()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                
                return true;
            }
            return false;
        }
        public bool comprarCarta()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                int valor = random.Next(1, 7);
                if(valor == 6)
                {
                    Debug.Log("Trunfo Comprado");
                    adicionaTrunfosAleatorios(1);
                }
                return true;
            }
            return false;
        }

        public bool abrirInventario()
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                return true;
            }
            return false;

        }

        public void usaTrunfo(Trunfo trunfo, Jogador Adversario)
        {

        }

        private int calculaVida() { return 0; }

        private int calculaMao() { return 0; }

        public int getSoma() { return this.soma; }

    }
