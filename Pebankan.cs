using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Nasabah
{
    public string Nama { get; set; }
    public long  NomorRekening { get; set; }
    public string Alamat { get; set; }

    public Nasabah(string nama, long nomorRekening, string alamat)
    {
        Nama = nama;
        NomorRekening = nomorRekening;
        Alamat = alamat;
    }
}

public interface IRekeningBank
{
    void SetorTunai(decimal jumlah);
    void TarikTunai(decimal jumlah);
    decimal CekSaldo();
    void BungaBulanan();
}


public abstract class Rekening : IRekeningBank
{
    protected decimal saldo;
    protected Nasabah nasabah;
    protected decimal minimumSetoran = 50000;

    public virtual void SetorTunai(decimal jumlah)
    {
        if (jumlah < minimumSetoran)
        {
            Console.WriteLine("Setoran Tunai minimal adalah Rp. 50.0000.");
            return;
        }
        saldo += jumlah;
        Console.WriteLine("Setor Tunai berhasil.");
    }

    public virtual void TarikTunai(decimal jumlah)
    {
        saldo -= jumlah;
    }

    public decimal CekSaldo()
    {
        return saldo;
    }

    public Nasabah GetNasabah()
    {
        return nasabah;
    }

    public void SetNasabah(Nasabah nasabah)
    {
        this.nasabah = nasabah;
    }

    public abstract void BungaBulanan();
}

public class Tabungan : Rekening
{
    private decimal bunga;

    public Tabungan(decimal saldoAwal, decimal bunga, Nasabah nasabah)
    {
        this.saldo = saldoAwal;
        this.bunga = bunga;
        SetNasabah(nasabah);
    }

    public override void SetorTunai(decimal jumlah)
    {
        base.SetorTunai(jumlah);
    }

    public void TambahBunga()
    {
        saldo += saldo * bunga;
    }

    public override void BungaBulanan()
    {
        saldo += saldo * bunga;
    }
}

public class Giro : Rekening
{
    private decimal LimitPenarikan;

    public Giro(decimal saldoAwal, decimal batasPenarikan, Nasabah nasabah)
    {
        this.saldo = saldoAwal;
        this.LimitPenarikan = batasPenarikan;
        SetNasabah(nasabah);
    }

    public override void TarikTunai(decimal jumlah)
    {
        if (saldo - jumlah >= -LimitPenarikan)
        {
            saldo -= jumlah;
        }
        else
        {
            Console.WriteLine("Penarikan melebihi saldo dan batas penarikan.");
        }
    }

    public override void BungaBulanan()
    {

    }
}
