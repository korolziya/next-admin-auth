import { VerifyForm } from "@/components/auth/verify-form";
import { Suspense } from "react";

export default function VerifyPage() {
  return (
    <Suspense fallback={<div>Yükleniyor...</div>}>
      <VerifyForm />
    </Suspense>
  );
}

