"use server"

import { z } from "zod"
import { signIn, signOut } from "@/auth"
import { AuthError } from "next-auth"
import { LoginSchema, RegisterSchema, VerifySchema } from "@/lib/schemas"

const API_URL = "http://localhost:5000/api/auth";

// We use FormData for register because it includes file upload
export async function register(formData: FormData) {
  // Manual validation or extraction since we are passing raw FormData
  // Note: We are forwarding this FormData directly to the backend API
  
  try {
      // Backend expects multipart/form-data. 
      // fetch automatically sets Content-Type to multipart/form-data when body is FormData
      // BUT we need to be careful with boundaries.
      // In Node.js environment (Server Action), sending FormData directly might require some care.
      
      const res = await fetch(`${API_URL}/register`, {
          method: "POST",
          body: formData, // Sending FormData directly
          // Do NOT set Content-Type header manually for FormData, fetch does it with boundary
      });
      
      const data = await res.json();
      
      if (!res.ok) {
          return { error: data.error || "Bir hata oluştu" };
      }

      return { success: data.success || "Kayıt başarılı" };
  } catch (error) {
      console.error(error);
      return { error: "Sunucu hatası" };
  }
}

export async function verify(values: z.infer<typeof VerifySchema>) {
    const validatedFields = VerifySchema.safeParse(values)

    if (!validatedFields.success) {
      return { error: "Geçersiz kod!" }
    }

    try {
        const res = await fetch(`${API_URL}/verify`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(validatedFields.data)
        });
        
        const data = await res.json();
        
        if (!res.ok) {
            return { error: data.error || "Bir hata oluştu" };
        }
  
        return { success: data.success || "Doğrulama başarılı" };
    } catch (error) {
        console.error(error);
        return { error: "Sunucu hatası" };
    }
}

export async function login(values: z.infer<typeof LoginSchema>) {
  console.log("SERVER: login action başladı", values);
  const validatedFields = LoginSchema.safeParse(values)

  if (!validatedFields.success) {
    return { error: "Geçersiz alanlar!" }
  }

  const { email, password } = validatedFields.data

  try {
    console.log("SERVER: signIn fonksiyonu çağrılıyor...");
    await signIn("credentials", {
      email,
      password,
      redirectTo: "/dashboard",
    })
  } catch (error) {
    console.error("SERVER: signIn hata fırlattı:", error);
    
    if ((error as Error).message === "NEXT_REDIRECT") {
      throw error;
    }
    
    if (error instanceof AuthError) {
      switch (error.type) {
        case "CredentialsSignin":
          return { error: "Geçersiz bilgiler!" }
        default:
          return { error: "Bir hata oluştu!" }
      }
    }
    throw error
  }
}

export async function logout() {
  await signOut({ redirectTo: "/login" });
}
