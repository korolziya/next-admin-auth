"use client"

import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { VerifySchema } from "@/lib/schemas"
import { z } from "zod"
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card"
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { useTransition, useEffect } from "react"
import { verify } from "@/actions/auth-actions"
import { toast } from "sonner"
import { useRouter, useSearchParams } from "next/navigation"

export const VerifyForm = () => {
  const [isPending, startTransition] = useTransition()
  const router = useRouter()
  const searchParams = useSearchParams()
  const emailParam = searchParams.get("email")

  const form = useForm<z.infer<typeof VerifySchema>>({
    resolver: zodResolver(VerifySchema),
    defaultValues: {
      email: emailParam || "",
      code: "",
    },
  })

  // Update form if URL param changes or loads late
  useEffect(() => {
    if (emailParam) {
        form.setValue("email", emailParam)
    }
  }, [emailParam, form])

  const onSubmit = (values: z.infer<typeof VerifySchema>) => {
    startTransition(() => {
      verify(values).then((data) => {
        if (data.error) {
          toast.error(data.error)
        }
        
        if (data.success) {
          toast.success(data.success)
          router.push("/login")
        }
      })
    })
  }

  return (
    <Card className="w-[400px]">
      <CardHeader>
        <CardTitle className="text-2xl font-bold text-center">Hesabı Doğrula</CardTitle>
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
                    <Input placeholder="ornek@site.com" {...field} disabled={true} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="code"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Doğrulama Kodu</FormLabel>
                  <FormControl>
                    <Input 
                        placeholder="123456" 
                        {...field} 
                        disabled={isPending} 
                        maxLength={6}
                        className="text-center text-lg tracking-widest"
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type="submit" className="w-full" disabled={isPending}>
              Doğrula
            </Button>
          </form>
        </Form>
      </CardContent>
    </Card>
  )
}

