import { auth } from "@/auth"
import { Sidebar } from "@/components/layout/sidebar"
import { Header } from "@/components/layout/header"
import { getMenu } from "@/actions/menu-actions"

export default async function DashboardLayout({
    children,
}: {
    children: React.ReactNode
}) {
    const session = await auth();
    const menuItems = await getMenu();

    const user = {
        name: `${(session?.user as any)?.firstName || ''} ${(session?.user as any)?.lastName || ''}`.trim() || (session?.user?.email || ''),
        email: session?.user?.email || '',
        companyName: (session?.user as any)?.companyName || 'Şirket',
        companyLogo: (session?.user as any)?.companyLogo
    };

    return (
        <div className="flex min-h-screen flex-col md:flex-row bg-background">
            {/* Sidebar (Desktop) */}
            <aside className="hidden w-64 flex-col md:flex">
                <Sidebar 
                    menuItems={menuItems} 
                    companyName={user.companyName}
                    className="h-full"
                />
            </aside>

            {/* Main Content Area */}
            <div className="flex flex-1 flex-col">
                <Header user={user} />
                <main className="flex-1 space-y-4 p-8 pt-6">
                    {children}
                </main>
            </div>
        </div>
    )
}
