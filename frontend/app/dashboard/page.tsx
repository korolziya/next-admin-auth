import { auth } from "@/auth"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { DollarSign, Users, CreditCard, Activity } from "lucide-react"

export default async function DashboardPage() {
  const session = await auth()

  return (
    <>
      <div className="flex items-center justify-between space-y-2">
        <h2 className="text-3xl font-bold tracking-tight">Dashboard</h2>
        <div className="flex items-center space-x-2">
           {/* DatePicker vs eklenebilir */}
        </div>
      </div>
      
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
        <Card>
          <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
            <CardTitle className="text-sm font-medium">
              Toplam Gelir
            </CardTitle>
            <DollarSign className="h-4 w-4 text-muted-foreground" />
          </CardHeader>
          <CardContent>
            <div className="text-2xl font-bold">$45,231.89</div>
            <p className="text-xs text-muted-foreground">
              +20.1% geçen aydan
            </p>
          </CardContent>
        </Card>
        <Card>
          <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
            <CardTitle className="text-sm font-medium">
              Abonelikler
            </CardTitle>
            <Users className="h-4 w-4 text-muted-foreground" />
          </CardHeader>
          <CardContent>
            <div className="text-2xl font-bold">+2350</div>
            <p className="text-xs text-muted-foreground">
              +180.1% geçen aydan
            </p>
          </CardContent>
        </Card>
        <Card>
          <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
            <CardTitle className="text-sm font-medium">Satışlar</CardTitle>
            <CreditCard className="h-4 w-4 text-muted-foreground" />
          </CardHeader>
          <CardContent>
            <div className="text-2xl font-bold">+12,234</div>
            <p className="text-xs text-muted-foreground">
              +19% geçen aydan
            </p>
          </CardContent>
        </Card>
        <Card>
          <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
            <CardTitle className="text-sm font-medium">Aktiflik</CardTitle>
            <Activity className="h-4 w-4 text-muted-foreground" />
          </CardHeader>
          <CardContent>
            <div className="text-2xl font-bold">+573</div>
            <p className="text-xs text-muted-foreground">
              +201 geçen saatten
            </p>
          </CardContent>
        </Card>
      </div>

      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7 mt-4">
        <Card className="col-span-4">
          <CardHeader>
            <CardTitle>Genel Bakış</CardTitle>
          </CardHeader>
          <CardContent className="pl-2">
            {/* Grafik buraya gelecek - Recharts kullanılabilir */}
            <div className="h-[200px] flex items-center justify-center text-muted-foreground">
                Grafik Alanı (Recharts kütüphanesi eklenebilir)
            </div>
          </CardContent>
        </Card>
        <Card className="col-span-3">
          <CardHeader>
            <CardTitle>Son Satışlar</CardTitle>
            <p className="text-sm text-muted-foreground">
              Bu ay 265 satış yaptınız.
            </p>
          </CardHeader>
          <CardContent>
            <div className="space-y-8">
              <div className="flex items-center">
                <div className="h-9 w-9 rounded-full bg-slate-200 flex items-center justify-center font-bold text-slate-600">
                    OM
                </div>
                <div className="ml-4 space-y-1">
                  <p className="text-sm font-medium leading-none">Olivia Martin</p>
                  <p className="text-sm text-muted-foreground">
                    olivia.martin@email.com
                  </p>
                </div>
                <div className="ml-auto font-medium">+$1,999.00</div>
              </div>
              <div className="flex items-center">
                <div className="h-9 w-9 rounded-full bg-slate-200 flex items-center justify-center font-bold text-slate-600">
                    JL
                </div>
                <div className="ml-4 space-y-1">
                  <p className="text-sm font-medium leading-none">Jackson Lee</p>
                  <p className="text-sm text-muted-foreground">jackson.lee@email.com</p>
                </div>
                <div className="ml-auto font-medium">+$39.00</div>
              </div>
              {/* Daha fazla örnek eklenebilir */}
            </div>
          </CardContent>
        </Card>
      </div>
    </>
  )
}
