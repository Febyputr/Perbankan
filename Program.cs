using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perbankan
{
   
        class Program
        {
            static void Main(string[] args)
            {
                Nasabah nasabah = new Nasabah("cha cha maricha", 45690752783813, "Jl. Sumatra No. 76");

                Tabungan tabungan = new Tabungan(50000, 0.05m, nasabah);
                Giro giro = new Giro(50000, 200000, nasabah);

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Setoran");
                    Console.WriteLine("2. Penarikan");
                    Console.WriteLine("3. Cek Saldo");
                    Console.WriteLine("4. Keluar");
                    Console.Write("Pilih menu (1-4): ");

                    int pilihan;
                    if (int.TryParse(Console.ReadLine(), out pilihan))
                    {
                        switch (pilihan)
                        {
                            case 1:
                                Console.WriteLine("Daftar Rekening:");
                                Console.WriteLine("1. Rekening Tabungan");
                                Console.WriteLine("2. Rekening Giro");
                                Console.Write("Pilih nomor rekening untuk setoran: ");
                                int nomorRekeningSetoran;
                                if (int.TryParse(Console.ReadLine(), out nomorRekeningSetoran))
                                {
                                    Console.Write("Masukkan jumlah setoran: ");
                                    decimal jumlahSetoran;
                                    if (decimal.TryParse(Console.ReadLine(), out jumlahSetoran))
                                    {
                                        if (nomorRekeningSetoran == 1)
                                        {
                                            tabungan.SetorTunai(jumlahSetoran);

                                        }
                                        else if (nomorRekeningSetoran == 2)
                                        {
                                            giro.SetorTunai(jumlahSetoran);

                                        }
                                        else
                                        {
                                            Console.WriteLine("Nomor rekening tidak valid.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Masukan tidak valid.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nomor rekening tidak valid.");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Daftar Rekening:");
                                Console.WriteLine("1. Rekening Tabungan");
                                Console.WriteLine("2. Rekening Giro");
                                Console.Write("Pilih nomor rekening untuk penarikan: ");
                                int nomorRekeningPenarikan;
                                if (int.TryParse(Console.ReadLine(), out nomorRekeningPenarikan))
                                {
                                    Console.Write("Masukkan jumlah penarikan: ");
                                    decimal jumlahPenarikan;
                                    if (decimal.TryParse(Console.ReadLine(), out jumlahPenarikan))
                                    {
                                        if (nomorRekeningPenarikan == 1)
                                        {
                                            tabungan.TarikTunai(jumlahPenarikan);
                                            Console.WriteLine("Penarikan berhasil dari Rekening Tabungan.");
                                        }
                                        else if (nomorRekeningPenarikan == 2)
                                        {
                                            giro.TarikTunai(jumlahPenarikan);
                                            Console.WriteLine("Penarikan berhasil dari Rekening Giro.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nomor rekening tidak valid.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Masukan tidak valid.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nomor rekening tidak valid.");
                                }
                                break;
                            case 3:
                                Console.WriteLine("Daftar Rekening:");
                                Console.WriteLine("1. Rekening Tabungan");
                                Console.WriteLine("2. Rekening Giro");
                                Console.Write("Pilih nomor rekening untuk cek saldo: ");
                                int nomorRekeningCekSaldo;
                                if (int.TryParse(Console.ReadLine(), out nomorRekeningCekSaldo))
                                {
                                    decimal saldo = 0;
                                    if (nomorRekeningCekSaldo == 1)
                                    {
                                        saldo = tabungan.CekSaldo();
                                    }
                                    else if (nomorRekeningCekSaldo == 2)
                                    {
                                        saldo = giro.CekSaldo();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nomor rekening tidak valid.");
                                    }

                                    if (saldo != 0)
                                    {
                                        Console.WriteLine($"Saldo Rekening {nomorRekeningCekSaldo}: {saldo}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nomor rekening tidak valid.");
                                }
                                break;
                            case 4:
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Menu tidak valid.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Masukan tidak valid.");
                    }

                    Console.WriteLine();
                }
            }
        }
    
}
