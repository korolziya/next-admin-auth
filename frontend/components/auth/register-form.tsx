"use client"

import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { RegisterSchema } from "@/lib/schemas"
import { z } from "zod"
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card"
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { useState, useTransition } from "react"
import { register } from "@/actions/auth-actions"
import { toast } from "sonner"
import { useRouter } from "next/navigation"
import Link from "next/link"

export const RegisterForm = () => {
  const [isPending, startTransition] = useTransition()
  const router = useRouter()

  const form = useForm<z.infer<typeof RegisterSchema>>({
    resolver: zodResolver(RegisterSchema),
    defaultValues: {
      email: "",
      password: "",
      firstName: "",
      lastName: "",
      companyName: "",
      birthDate: "",
      companyLogoUrl: ""
    },
  })

  // State for file
  const [logoFile, setLogoFile] = useState<File | null>(null);

  const onSubmit = (values: z.infer<typeof RegisterSchema>) => {
    startTransition(() => {
      const formData = new FormData();
      formData.append("email", values.email);
      formData.append("password", values.password);
      formData.append("firstName", values.firstName);
      formData.append("lastName", values.lastName);
      formData.append("companyName", values.companyName);
      if (values.birthDate) formData.append("birthDate", values.birthDate);
      if (logoFile) formData.append("logo", logoFile);

      register(formData).then((data) => {
        if (data.error) {
          toast.error(data.error)
        }
        
        if (data.success) {
          toast.success(data.success)
          router.push(`/verify?email=${values.email}`)
        }
      })
    })
  }

  return (
    <Card className="w-[500px]">
      <CardHeader>
        <CardTitle className="text-2xl font-bold text-center">Şirket Hesabı Oluştur</CardTitle>
      </CardHeader>
      <CardContent>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
            {/* ... other fields ... */}
            
            <div className="grid grid-cols-2 gap-4">
              <FormField
                control={form.control}
                name="firstName"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>İsim</FormLabel>
                    <FormControl>
                      <Input placeholder="Adınız" {...field} disabled={isPending} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="lastName"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Soyisim</FormLabel>
                    <FormControl>
                      <Input placeholder="Soyadınız" {...field} disabled={isPending} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>

            <FormField
              control={form.control}
              name="companyName"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Şirket Adı</FormLabel>
                  <FormControl>
                    <Input placeholder="Şirketinizin Adı" {...field} disabled={isPending} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />

            <FormField
              control={form.control}
              name="email"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input placeholder="ornek@sirket.com" {...field} disabled={isPending} />
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

             <div className="grid grid-cols-2 gap-4">
              <FormField
                control={form.control}
                name="birthDate"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Doğum Tarihi (İsteğe Bağlı)</FormLabel>
                    <FormControl>
                      <Input type="date" {...field} disabled={isPending} />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormItem>
                <FormLabel>Şirket Logosu (İsteğe Bağlı)</FormLabel>
                <FormControl>
                  <Input 
                    type="file" 
                    accept="image/*"
                    onChange={(e) => {
                      const file = e.target.files?.[0];
                      if (file) setLogoFile(file);
                    }} 
                    disabled={isPending} 
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            </div>

            <Button type="submit" className="w-full" disabled={isPending}>
              Kayıt Ol
            </Button>
          </form>
        </Form>
      </CardContent>
      <CardFooter className="justify-center">
        <Link href="/login" className="text-sm text-blue-500 hover:underline">
          Zaten hesabınız var mı? Giriş yapın
        </Link>
      </CardFooter>
    </Card>
  )
}

