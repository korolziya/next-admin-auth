"use client"

import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { LoginSchema } from "@/lib/schemas"
import { z } from "zod"
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card"
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { useTransition } from "react"
import { login } from "@/actions/auth-actions"
import { toast } from "sonner"
import { useRouter } from "next/navigation"
import Link from "next/link"

export const LoginForm = () => {
  const [isPending, startTransition] = useTransition()
  const router = useRouter()

  const form = useForm<z.infer<typeof LoginSchema>>({
    resolver: zodResolver(LoginSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  })

  const onSubmit = (values: z.infer<typeof LoginSchema>) => {
    console.log("CLIENT: Form submit tetiklendi", values);
    startTransition(() => {
      console.log("CLIENT: Login action çağrılıyor...");
      login(values).then((data) => {
        console.log("CLIENT: Login action sonucu:", data);
        if (data?.error) {
          toast.error(data.error)
        }
        
        // Success handled by redirect in action
      }).catch((err) => {
        console.error("Login Form Hatası:", err);
        toast.error("Bir hata oluştu: " + (err.message || "Bilinmeyen hata"));
      })
    })
  }

  return (
    <Card className="w-[400px]">
      <CardHeader>
        <CardTitle className="text-2xl font-bold text-center">Giriş Yap</CardTitle>
      </CardHeader>
      <CardContent>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6">
            <FormField
              control={form.control}
              name="email"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input placeholder="ornek@site.com" {...field} disabled={isPending} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="password"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Şifre</FormLabel>
                  <FormControl>
                    <Input type="password" placeholder="******" {...field} disabled={isPending} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type="submit" className="w-full" disabled={isPending}>
              Giriş Yap
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter className="justify-center">
        <Link href="/register" className="text-sm text-blue-500 hover:underline">
          Hesabınız yok mu? Kayıt olun
        </Link>
      </CardFooter>
    </Card>
  )
}

