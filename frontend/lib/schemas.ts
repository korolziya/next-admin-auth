import { z } from "zod"

// File validation is tricky on server actions/zod serialization.
// We will handle file validation partially on client or accept any for now in schema
// but logic will handle FormData.
export const RegisterSchema = z.object({
  email: z.string().email("Geçerli bir email adresi giriniz"),
  password: z.string().min(6, "Şifre en az 6 karakter olmalıdır"),
  firstName: z.string().min(1, "İsim gereklidir"),
  lastName: z.string().min(1, "Soyisim gereklidir"),
  companyName: z.string().min(1, "Şirket adı gereklidir"),
  birthDate: z.string().optional(),
  // Logo validation will be handled manually since passing File via Server Action requires FormData
})

export const LoginSchema = z.object({
  email: z.string().email("Geçerli bir email adresi giriniz"),
  password: z.string().min(1, "Şifre gereklidir"),
})

export const VerifySchema = z.object({
  email: z.string().email(),
  code: z.string().length(6, "Kod 6 haneli olmalıdır"),
})
